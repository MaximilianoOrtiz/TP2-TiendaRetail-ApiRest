namespace Application.Dtos.Product
{
    public class DTOProductResponse
    {
        public Guid ProductoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string UrlImage { get; set; }

        public override string ToString()
        {
            return $"Nombre: {Name}\n" +
                   $"Descripción: {Description}\n" +
                   $"Precio: ${Price}\n" +
                   $"Descuento: {Discount}%\n" +
                   $"URL de la Imagen: {UrlImage}";
        }
    }
}
