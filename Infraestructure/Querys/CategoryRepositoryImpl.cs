using Application.Interfaces.Repository;
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

        public async Task<List<Category>> FindAllCategoryAsync()
        {
            return _context.Category.ToList();
        }

        public async Task<Category> FindCategoryByIdAsync(int categoryId)
        {
            var item = (from category in _context.Category
                        where category.CategoryId == categoryId
                        select category).FirstOrDefault();
            return item;
        }
    }
}
