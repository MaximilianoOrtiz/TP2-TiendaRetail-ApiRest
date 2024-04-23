namespace Application.Dtos.Product
{
    public class DTOProdutcRequest
    {
        public Guid ProductoId { get; set; }
        public int Quantity { get; set; }

        public DTOProdutcRequest(Guid productoId, int quantity)
        {
            ProductoId = productoId;
            Quantity = quantity;
        }
    }
}
