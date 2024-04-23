namespace Domain.Entitys
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set;}

        public Category(int categoryId, string name)
        {
            CategoryId = categoryId;
            Name = name;
        }
    }
}
