namespace Application.Dtos.Product
{
    public class ProductoGetResponse
    {
        public Guid ProductoId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int? discount { get; set; }
        public string urlImage { get; set; }

        public int categoriaId { get; set; }
    }
}
