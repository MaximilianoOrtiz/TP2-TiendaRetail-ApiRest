using Application.Interfaces;
using Domain.Entitys;

namespace Infraestructure.Querys
{
    public class CategoryRepositoryImpl : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepositoryImpl(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<List<Category>> findAllCategory()
        {
            return _context.Categories.ToList();
        }

        public async Task<Category> findCateegoryById(int categoryId)
        {
            var item = (from category in _context.Categories
                        where category.CategoryId == categoryId
                        select category).FirstOrDefault();
            return item;
        }
    }
}
