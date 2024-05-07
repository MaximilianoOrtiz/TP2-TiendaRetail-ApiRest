namespace Domain.Entitys
{
    public class SaleProduct
    {
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int? Discount { get; set; }

        public int SaleId { get; set; }
        public Sale Sales { get; set; }

        public Guid ProductId { get; set; }
        public Product Products { get; set; }
    }
}
