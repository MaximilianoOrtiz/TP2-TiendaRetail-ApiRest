using Application.Dtos.Product;
namespace Application.Dtos.Sale
{
    public class DTOSaleRequest
    {
        public List<DTOProdutcRequest> ShoppingCart { get; set; }
        public DTOTotalPrinceSaleResponse TotalPrinceShoppingCart { get; set; }
    }
}
