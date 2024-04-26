using Swashbuckle.AspNetCore.Annotations;

namespace Application.Dtos.Category
{
    public class CategoryDTO
    {
        [SwaggerSchema(Description = "ID de la categoria")]
        public int CategoryId { get; set; }

        [SwaggerSchema(Description = "Nombre de la categoria")]
        public string Name { get; set; }

    }
}
