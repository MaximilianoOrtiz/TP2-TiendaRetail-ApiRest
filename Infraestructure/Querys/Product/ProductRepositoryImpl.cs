using Application.Interfaces;
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
        /*
        public async Task<Product> findProductById(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.ProductoId == id);
        }
        */
        /*
        public List<Product> findProductbyIdCategory(int idCategory)
        {
            var products = (from product in _context.Products
                            where product.categoryId == idCategory
                            select product).ToList();
            return products;
        }
        */
        public async Task<List<Product>> findProductByCategoryIdAndName(int categoryId, string name)
        {
            var products = (from product in _context.Products
                            where product.categoryId == categoryId
                            && product.Name.Contains(name)
                            select product).ToList();

            return products;
        }

        public async Task<List<Product>> findProductByName(string name)
        {
            var products = (from product in _context.Products
                            where product.Name.Contains(name)
                            select product).ToList();
            return products;
        }
    }

}
