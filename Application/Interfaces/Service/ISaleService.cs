using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;

namespace Application.Interfaces.Service
{
    public interface ISaleService
    {
        public Task<SaleResponse> SaveSale(SaleRequest saleRequest);

        public Task<SaleResponse> FindSaveById(int saveId);

    }
}
