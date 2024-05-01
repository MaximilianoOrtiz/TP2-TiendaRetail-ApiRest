using Aplication.Dtos.Sale.TotalPrince;
using Domain.Dtos.Product;
namespace Domain.Dtos.Sale
{
    public class DTOSaleRequest
    {
        public List<DTOProdutcRequest> ShoppingCart { get; set; }
        public DTOTotalPrinceSaleResponse TotalPrinceShoppingCart { get; set; }
    }
}
