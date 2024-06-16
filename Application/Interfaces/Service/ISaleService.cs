using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;

namespace Application.Interfaces.Service
{
    public interface ISaleService
    {
        public Task<SaleResponse> SaveSaleAsync(SaleRequest saleRequest);
        public Task<SaleResponse> FindSaveByIdAsync(int saveId);
        public Task<List<SaleGetResponse>> GetFilterByDateTimeAsync(DateTime from, DateTime to);
    }
}
