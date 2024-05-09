using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using Application.Exceptions;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
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
        private readonly ISaleRepository _saleRepository;
        private readonly ILogger<SaleServiceImpl> _logger;
        private readonly IMapper _mapper;

        public SaleServiceImpl(IGenericRepository genericRepository,
                               ILogger<SaleServiceImpl> logger,
                               IMapper mapper,
                               ICalculatorService calculatorService,
                               IProductRepository productRepository,
                               IParametryRepository parametryRepository,
                               ISaleRepository saleRepository)
        {
            _genericRepository = genericRepository;
            _logger = logger;
            _mapper = mapper;
            _calculatorService = calculatorService;
            _productRepository = productRepository;
            _parametryRepository = parametryRepository;
            _saleRepository = saleRepository;
        }

        public async Task<SaleResponse> SaveSaleAsync(SaleRequest saleRequest)
        {
            _logger.LogInformation("Init - SaveSaleAsync");

            SaleResponse saleResponse = await _calculatorService.CalculatePriceAsync(saleRequest.Products);

            _logger.LogInformation("Valido que el total ingresado sea igual al calulado por el sistema");
            if (saleResponse.TotalPay != saleRequest.TotalPayed)
            {
                throw new CustomException("El total ingresado no coincide con el calculo realizado por el sistema.");
            }

            _logger.LogInformation("Inicio la carga y conteo de los productos a partir del Request");
            List<SaleProduct> listSaleProducts = new List<SaleProduct>();
            int totalQuantity = 0;

            foreach (SaleProductRequest saleProductRequest in saleRequest.Products)
            {
                Product product = await _productRepository.FindProductByIdAsync(saleProductRequest.ProductId);
                //Obtengo el precio y descuento desde el producto
                SaleProduct saleProduct = _mapper.Map<SaleProduct>(product);
                saleProduct.Quantity = saleProductRequest.Quantity;
                saleProduct.Product = product;
                totalQuantity += saleProductRequest.Quantity;
                listSaleProducts.Add(saleProduct);
            }

            //Armo la Venta para persistirla en base
            //Obtengo  el TotalPay, SubTotal y TotalDiscount del saleResponse
            Sale sale = _mapper.Map<Sale>(saleResponse);
            sale.Taxes = await _parametryRepository.FindValueByCodeAsync("taxe_iva");
            sale.Date = DateTime.Now;
            sale.SaleProducts = listSaleProducts;

            saleResponse = _mapper.Map<SaleResponse>(await _genericRepository.SaveAsync(sale));
            saleResponse.TotalQuantity = totalQuantity;

            _logger.LogInformation("Out - SaveSaleAsync");
            return saleResponse;
        }

        public async Task<SaleResponse> FindSaveByIdAsync(int saveId)
        {
            _logger.LogInformation("Init - FindSaveByIdAsync");
            Sale sale = await _saleRepository.FindSaleByIdAsync(saveId);
            if (sale == null) { return null; }

            SaleResponse saleResponse = _mapper.Map<SaleResponse>(sale);
            saleResponse.TotalQuantity = sale.SaleProducts.Count;

            _logger.LogInformation("Out - FindSaveByIdAsync");
            return saleResponse;
        }

        public async Task<List<SaleGetResponse>> GetFilterByDateTime(DateTime from, DateTime to)
        {
            _logger.LogInformation("Init - FindSaleByDateFilter");
            List<SaleGetResponse> response = new List<SaleGetResponse>();

            List<Sale> listSale = await _saleRepository.FindSaleByDateFilter(from, to);

            foreach (Sale sale in listSale)
            {
                var saleAux = _mapper.Map<SaleGetResponse>(sale);
                saleAux.TotalQuantity = sale.SaleProducts.Count;
                response.Add(saleAux);
            }
            _logger.LogInformation("Out - FindSaleByDateFilter");
            return response;
        }
    }
}
