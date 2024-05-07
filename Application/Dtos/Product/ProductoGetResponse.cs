namespace Application.Dtos.Product
{
    public class ProductoGetResponse
    {
        public Guid ProductoId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string UrImage { get; set; }

        public int CategoriaId { get; set; }
    }
}
