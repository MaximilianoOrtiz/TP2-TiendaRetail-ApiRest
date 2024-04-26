namespace Application.Dtos.Product
{
    public class ProductoGetResponse
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int? discount { get; set; }
        public string urlImage { get; set; }

        public int categoriaName { get; set; }
    }
}
