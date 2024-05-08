namespace Application.Dtos.Product
{
    public class ProductoGetResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string ImageUrl { get; set; }

        public string CategoriaName { get; set; }
    }
}
