using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Sale.Request
{
    public class SaleProductRequest
    {
        [Required(ErrorMessage = "El ProductId es requerido")]
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor que cero")]
        public int Quantity { get; set; }
    }
}
