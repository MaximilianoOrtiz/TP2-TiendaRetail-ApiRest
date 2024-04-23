using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entitys;


namespace Infraestructure.DataSet
{
    public class ParametryDummy : IEntityTypeConfiguration<Parametry>
    {
        public void Configure(EntityTypeBuilder<Parametry> builder)
        {
            builder.HasData(
                new Parametry(1, "taxe_iva", 21)
            );
        }
    }
}
