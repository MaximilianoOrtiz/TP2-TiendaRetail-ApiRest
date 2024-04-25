using Application.Dtos.Product;
using Application.Dtos.Sale;

namespace Application.Interfaces
{
    public interface ISaleService
    {
        public Task<DTOTotalPrinceSaleResponse> calculatePrinceTotal(List<DTOProdutcRequest> ShoppingCart);

        public Task<DTOSaleResponse> saveSale(DTOSaleRequest request);
    }
}
