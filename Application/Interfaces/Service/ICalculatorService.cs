using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;

namespace Application.Interfaces.Service
{
    public interface ICalculatorService
    {
        public Task<SaleResponse> CalculatePriceAsync(List<SaleProductRequest> products);
    }
}
