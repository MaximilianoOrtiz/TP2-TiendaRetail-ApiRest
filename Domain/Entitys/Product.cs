namespace Domain.Entitys
{
    public class Product
    {
        public Guid ProductoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string UrlImage { get; set; }

        public int categoryId { get; set; }
        public Category Category { get; set; }

        public IList<SaleProduct> SaleProducts { get; set; }

        public Product(Guid productoId, string name, string description, decimal price, int? discount, string urlImage, int categoryId)
        {
            ProductoId = productoId;
            Name = name;
            Description = description;
            Price = price;
            Discount = discount;
            UrlImage = urlImage;
            this.categoryId = categoryId;
        }
    }
}
