using Application.Interfaces.Repository;
using Domain.Entitys;

namespace Infraestructure.Querys
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepositoryImpl(ApplicationDbContext applicationDbContex)
        {
            this._context = applicationDbContex;
        }

        public async Task<Product> FindProductByEqualNameAsync(string name)
        {
            return (from product in _context.Product
                    where product.Name == name
                    select product).FirstOrDefault();
        }

        /*
        public List<Product> findProductbyIdCategory(int idCategory)
        {
            var products = (from product in _context.Product
                            where product.CategoryId == idCategory
                            select product).ToList();
            return products;
        }
        */
        public async Task<List<Product>> FindProductByCategoryIdAndNameAsync(int categoryId, string name)
        {
            var products = (from product in _context.Product
                            where product.CategoryId == categoryId
                            && product.Name.Contains(name)
                            select product).ToList();

            return products;
        }

        public async Task<List<Product>> FindProductByNameAsync(string name)
        {
            var products = (from product in _context.Product
                            where product.Name.Contains(name)
                            select product).ToList();
            return products;
        }

        public async Task<Product> FindProductByIdAsync(Guid productoId)
        {
            var products = (from product in _context.Product
                            where product.ProductoId == productoId
                            select product).FirstOrDefault();
            return products;

        }
    }
}
