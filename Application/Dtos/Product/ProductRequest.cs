
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class ProductRequest
    {
        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del producto no puede tener más de 100 caracteres.")]
        public string Name { get; set; }

        [StringLength(600, ErrorMessage = "La descripción del producto no puede tener más de 600 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El precio del producto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio del producto debe ser mayor que cero.")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "El descuento del producto debe estar entre 0 y 100.")]
        public int? Discount { get; set; }

        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "El ID de la categoría es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ID de la categoría debe ser mayor que cero.")]
        public int Category { get; set; }
    }
}
