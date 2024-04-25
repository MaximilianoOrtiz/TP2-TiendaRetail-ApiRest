using Application.Interfaces;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepositoryImpl(ApplicationDbContext applicationDbContex)
        {
            this._context = applicationDbContex;
        }

        public async Task<Product> findProductById(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(product => product.ProductoId == id);
        }

        public List<Product> findProductbyIdCategory(int idCategory)
        {
            var products = (from product in _context.Products
                            where product.Category.CategoryId == idCategory
                            select product).ToList();
            return products;
        }
    }
}
