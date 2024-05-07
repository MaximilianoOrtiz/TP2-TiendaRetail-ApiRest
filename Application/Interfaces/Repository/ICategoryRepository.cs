using Domain.Entitys;

namespace Application.Interfaces.Repository
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> FindAllCategoryAsync();
        public Task<Category> FindCategoryByIdAsync(int categoryId);
    }
}
