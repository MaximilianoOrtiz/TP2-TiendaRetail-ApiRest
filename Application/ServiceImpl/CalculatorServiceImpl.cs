using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using Application.Exceptions;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Domain.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.UseCase
{
    public class CalculatorServiceImpl : ICalculatorService
    {
        private readonly IParametryRepository _parametryRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CalculatorServiceImpl> _logger;

        public CalculatorServiceImpl(IParametryRepository parametryRepository,
                                     ILogger<CalculatorServiceImpl> logger,
                                     IProductRepository productRepository)
        {
            _parametryRepository = parametryRepository;
            _logger = logger;
            _productRepository = productRepository;
        }

        public async Task<SaleResponse> CalculatePriceAsync(List<SaleProductRequest> products)
        {
            _logger.LogInformation("Init - CalculatePriceAsync");
            decimal taxes = await _parametryRepository.FindValueByCodeAsync("taxe_iva");
            SaleResponse saleResponse = new SaleResponse();

            _logger.LogInformation("Inicio el recorrido de los productos y calculo el Subtotal y TotalDicount");
            foreach (SaleProductRequest item in products)
            {
                Product product = await _productRepository.FindProductByIdAsync(item.ProductId);
                if (product != null)
                {
                    decimal princeTotalProduct = product.Price * item.Quantity;

                    //Actualizo el Subtotal en el saleResponse. Es la suma de los productos sin ningun tipo de descuento e impuesto.
                    saleResponse.SubTotal += princeTotalProduct;

                    //Obtengo el descuento y lo sumo en el saleResponse.
                    if (product.Discount != null && product.Discount != 0)
                        saleResponse.TotalDiscount += princeTotalProduct * Convert.ToDecimal(product.Discount) / 100;
                }
                else
                {
                    throw new CustomExceptionBadRequest("No existe el producto con Id: " + item.ProductId
                                              + " en la bases de datos al momento de realizar la verificación del precio total");
                }
            }
            //Calculo el TotalPay
            decimal totalPayTem = saleResponse.SubTotal - saleResponse.TotalDiscount;
            decimal aux = totalPayTem + (totalPayTem * (taxes / 100));
            saleResponse.TotalPay = Math.Round(aux, 2);

            _logger.LogInformation("Init - CalculatePriceAsync");
            return saleResponse;
        }

        public int CalculateTotalQuantity(List<SaleProductRequest> products)
        {
            int totalQuantity = 0;
            foreach (SaleProductRequest item in products)
            {
                totalQuantity += item.Quantity;
            }

            return totalQuantity;
        }

        public int CalculateTotalQuantityFromSaleProduct(IList<SaleProduct> products)
        {
            int totalQuantity = 0;

            foreach (SaleProduct item in products)
            {
                totalQuantity += item.Quantity;
            }

            return totalQuantity;
        }
    }
}
