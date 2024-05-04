using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IParametry;
using Application.Interfaces.IProduct;
using Application.Interfaces.ISale;
using Application.Interfaces.IUtil;
using AutoMapper;
using Domain.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.UseCase
{
    public class SaleServiceImpl : ISaleService
    {
        private readonly IGenericRepository _genericRepository;
        private readonly ICalculatorService _calculatorService;
        private readonly IProductRepository _productRepository;
        private readonly IParametryRepository _parametryRepository;
        private readonly ILogger<SaleServiceImpl> _logger;
        private readonly IMapper _mapper;

        public SaleServiceImpl(
            IGenericRepository genericRepository,
            ILogger<SaleServiceImpl> logger,
            IMapper mapper,
            ICalculatorService calculatorService,
            IProductRepository productRepository,
            IParametryRepository parametryRepository)
        {
            _genericRepository = genericRepository;
            _logger = logger;
            _mapper = mapper;
            _calculatorService = calculatorService;
            _productRepository = productRepository;
            _parametryRepository = parametryRepository;
        }

        public async Task<SaleResponse> saveSale(SaleRequest saleRequest)
        {
            _logger.LogInformation("Init - saveSale");

            SaleResponse saleResponse = await _calculatorService.calculatePrince(saleRequest.Products);

            _logger.LogInformation("Valido que el total ingresado sea igual al calulado por el sistema");
            if (saleResponse.TotalPay != saleRequest.TotalPayed)
            {
                throw new CustomException("El total ingresado no coincide con el calculo realizado por el sistema.");
            }

            List<SaleProduct> listSaleProducts = new List<SaleProduct>();
            List<SaleProductResponse> listSaleProductResponses = new List<SaleProductResponse>();

            _logger.LogInformation("Inicio la carga de los productos a partir del Request");
            foreach (SaleProductRequest item in saleRequest.Products)
            {
                Product product = await _productRepository.findProductById(item.ProductId);

                SaleProduct saleProduct = new SaleProduct();
                saleProduct.Products = product;
                saleProduct.Price = product.Price;
                saleProduct.Discount = product.Discount;
                saleProduct.Quantity = item.Quantity;
                listSaleProducts.Add(saleProduct);
                //Mapeo y armo mi lista a responder
                listSaleProductResponses.Add(_mapper.Map<SaleProductResponse>(product));
            }

            Sale sale = _mapper.Map<Sale>(saleResponse);
            sale.Taxes = await _parametryRepository.findValueByCodigo("taxe_iva");
            sale.DateTime = DateTime.Now;
            sale.SaleProducts = listSaleProducts;

            saleResponse = _mapper.Map<SaleResponse>(await _genericRepository.save(sale));


            //Termino de armar la respuesta incorporando el saleId a cada producto
            foreach (SaleProductResponse item in listSaleProductResponses)
            {
                item.SaleId = saleResponse.SaleId;
            }
            saleResponse.Products = listSaleProductResponses;

            _logger.LogInformation("Out - saveSale");
            return saleResponse;
        }
    }
}
