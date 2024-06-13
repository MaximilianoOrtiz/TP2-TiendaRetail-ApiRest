namespace Application.Dtos.Product.Response
{
    public class ProductoGetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }
    }
}
