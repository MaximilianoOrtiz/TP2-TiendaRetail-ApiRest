using Domain.Entitys;
using Infraestructure.DataSet;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public DbSet<Parametry> Parametries { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se configuran las tablas utilizando Fuent Api para facilitar el mantenimiento

            //Configuracion de la entidad Sale
            modelBuilder.Entity<Sale>().ToTable("Sales");
            modelBuilder.Entity<Sale>()
                .HasKey(sale => sale.SaleId);
            modelBuilder.Entity<Sale>()
                .Property(sale => sale.SaleId)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(sale => sale.TotalPay)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(sale => sale.SubTotal)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(sale => sale.TotalDiscount)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(sale => sale.Taxes)
                .IsRequired();
            modelBuilder.Entity<Sale>()
                .Property(sale => sale.DateTime);

            //Configuracion de la entidad Producto
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>()
                .HasKey(product => product.ProductoId);
            modelBuilder.Entity<Product>()
                .Property(product => product.ProductoId)
                .IsRequired();
            modelBuilder.Entity<Product>()
               .Property(product => product.Name)
               .HasMaxLength(100)
               .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(product => product.Description);
            modelBuilder.Entity<Product>()
                .Property(product => product.Price)
                .IsRequired();
            modelBuilder.Entity<Product>()
                .Property(product => product.Discount)
                .IsRequired(false);
            modelBuilder.Entity<Product>()
              .Property(product => product.UrlImage);

            modelBuilder.Entity<Product>()
                .HasOne<Category>(product => product.Category)
                .WithMany(category => category.Products)
                .HasForeignKey(product => product.categoryId);

            //Configuracion de la entidad Category
            modelBuilder.Entity<Category>()
                .HasKey(category => category.CategoryId);
            modelBuilder.Entity<Category>()
                .Property(category => category.Name)
                .IsRequired();

            //Configuración de la entidad SaleProducts
            modelBuilder.Entity<SaleProduct>().ToTable("SaleProducts");
            modelBuilder.Entity<SaleProduct>()
                .HasKey(saleProduct => saleProduct.ShoppingCartId);
            modelBuilder.Entity<SaleProduct>()
                .Property(saleProduct => saleProduct.SaleId)
                .IsRequired();
            modelBuilder.Entity<SaleProduct>()
                .Property(saleProduct => saleProduct.ProductId)
                .IsRequired();
            modelBuilder.Entity<SaleProduct>()
                .Property(saleProduct => saleProduct.ShoppingCartId)
                .IsRequired();
            modelBuilder.Entity<SaleProduct>()
                .Property(saleProduct => saleProduct.Quantity)
                .IsRequired();
            modelBuilder.Entity<SaleProduct>()
                .Property(saleProduct => saleProduct.Price)
                .IsRequired();

            modelBuilder.Entity<SaleProduct>()
                .HasOne<Sale>(saleProduct => saleProduct.Sales)
                .WithMany(sale => sale.SaleProducts)
                .HasForeignKey(saleProduct => saleProduct.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SaleProduct>()
                .HasOne(saleProduct => saleProduct.Products)
                .WithMany(product => product.SaleProducts)
                .HasForeignKey(saleProduct => saleProduct.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            //Configuracion de Parametry
            modelBuilder.Entity<Parametry>()
                .HasKey(parametry => parametry.ParametriaId);
            modelBuilder.Entity<Parametry>()
                .Property(parametry => parametry.Codigo).IsRequired();
            modelBuilder.Entity<Parametry>()
              .Property(parametry => parametry.Value).IsRequired();

            //Aplicamos configuracion para generar carga de datos automaticamente
            modelBuilder.ApplyConfiguration(new CategorysDummy());
            modelBuilder.ApplyConfiguration(new ProductsDummy());
            modelBuilder.ApplyConfiguration(new ParametryDummy());

            base.OnModelCreating(modelBuilder);
        }
    }
}
