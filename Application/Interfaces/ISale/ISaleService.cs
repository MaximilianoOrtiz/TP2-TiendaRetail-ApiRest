using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;

namespace Application.Interfaces.ISale
{
    public interface ISaleService
    {
        //       public Task<DTOTotalPrinceSaleResponse> calculatePrinceTotal(List<DTOProdutcRequest> ShoppingCart);

        public Task<SaleResponse> saveSale(SaleRequest saleRequest);
    }
}
