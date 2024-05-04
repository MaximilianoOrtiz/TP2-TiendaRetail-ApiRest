namespace Application.Dtos.Sale.Response
{
    public class SaleProductResponse
    {
        public int SaleId { get; set; }
        public string ProductoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
    }
}
