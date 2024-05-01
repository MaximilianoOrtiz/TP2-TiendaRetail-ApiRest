using Domain.Entitys;

namespace Application.Dtos
{
    public class ProductResponse
    {
        public Guid ProductoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string UrlImage { get; set; }

        public CategoryDTO Category { get; set; }
    }
}
