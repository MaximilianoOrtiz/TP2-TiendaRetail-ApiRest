using Aplication.Dtos.Sale.TotalPrince;
using Domain.Dtos.Product;
using Domain.Dtos.Sale;

namespace Application.Interfaces.ISale
{
    public interface ISaleService
    {
        public Task<DTOTotalPrinceSaleResponse> calculatePrinceTotal(List<DTOProdutcRequest> ShoppingCart);

        public Task<DTOSaleResponse> saveSale(DTOSaleRequest request);
    }
}
