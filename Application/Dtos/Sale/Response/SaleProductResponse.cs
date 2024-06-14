namespace Application.Dtos.Sale.Response
{
    public class SaleProductResponse
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
    }
}
