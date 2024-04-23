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
    }
}
