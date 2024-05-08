using Swashbuckle.AspNetCore.Annotations;

namespace Application.Dtos
{
    public class CategoryDTO
    {
        [SwaggerSchema(Description = "ID de la categoria")]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Nombre de la categoria")]
        public string Name { get; set; }

    }
}
