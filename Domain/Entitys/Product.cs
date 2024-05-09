namespace Domain.Entitys
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IList<SaleProduct> SaleProducts { get; set; }

        public Product() { }
        public Product(Guid productoId, string name, string description, decimal price, int? discount, string urlImage, int categoryId)
        {
            ProductId = productoId;
            Name = name;
            Description = description;
            Price = price;
            Discount = discount;
            ImageUrl = urlImage;
            this.CategoryId = categoryId;
        }
    }
}
