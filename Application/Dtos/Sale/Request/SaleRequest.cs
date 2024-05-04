using System.ComponentModel.DataAnnotations;

namespace Application.Dtos.Sale.Request
{
    public class SaleRequest
    {
        [Required(ErrorMessage = "La lista de productos es requerida")]
        public List<SaleProductRequest> Products { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "El total pagado debe ser mayor que cero")]
        public decimal TotalPayed { get; set; }
    }
}
