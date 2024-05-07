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
        private readonly ILogger<SaleServiceImpl> _logger;
        private readonly IMapper _mapper;

        public SaleServiceImpl(IGenericRepository genericRepository,
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

            SaleResponse saleResponse = await _calculatorService.CalculatePrinceAsync(saleRequest.Products);

            _logger.LogInformation("Valido que el total ingresado sea igual al calulado por el sistema");
            if (saleResponse.TotalPay != saleRequest.TotalPayed)
            {
                throw new CustomException("El total ingresado no coincide con el calculo realizado por el sistema.");
            }

            _logger.LogInformation("Inicio la carga de los productos a partir del Request");
            List<SaleProduct> listSaleProducts = new List<SaleProduct>();
            
            foreach (SaleProductRequest saleProductRequest in saleRequest.Products)
            {
                Product product = await _productRepository.FindProductByIdAsync(saleProductRequest.ProductId);
                SaleProduct saleProduct = _mapper.Map<SaleProduct>(saleProductRequest);
                saleProduct.Products = product;
                listSaleProducts.Add(saleProduct);
            }

            Sale sale = _mapper.Map<Sale>(saleResponse);
            sale.Taxes = await _parametryRepository.FindValueByCodigoAsync("taxe_iva");
            sale.DateTime = DateTime.Now;
            sale.SaleProducts = listSaleProducts;

            saleResponse = _mapper.Map<SaleResponse>(await _genericRepository.SaveAsync(sale));

            _logger.LogInformation("Out - saveSale");
            return saleResponse;
        }
    }
}
