using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;

namespace Application.Interfaces.IUtil
{
    public interface ICalculatorService
    {
        public Task<SaleResponse> calculatePrince(List<SaleProductRequest> products);
    }
}
