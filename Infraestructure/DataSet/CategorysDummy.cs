using Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.DataSet
{
    public class CategorysDummy : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category(1, "Electrodomésticos"),
                new Category(2, "Tecnologia y Electrónica"),
                new Category(3, "Moda y Accesorios"),
                new Category(4, "Hogar y Decoración"),
                new Category(5, "Salud y Belleza"),
                new Category(6, "Deportes y Ocio"),
                new Category(7, "Juguetes y Juegos"),
                new Category(8, "Alimentos y Bebidas"),
                new Category(9, "Libros y Material Eductivo"),
                new Category(10, "Jardineria y Bricola")
            );
        }
    }
}
