using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using Domain.Entitys;

namespace Application.Interfaces.Service
{
    public interface ICalculatorService
    {
        public Task<SaleResponse> CalculatePriceAsync(List<SaleProductRequest> products);
        public int CalculateTotalQuantity(List<SaleProductRequest> products);
        public int CalculateTotalQuantityFromSaleProduct(IList<SaleProduct> products);
    }
}
