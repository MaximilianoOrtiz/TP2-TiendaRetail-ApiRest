using Domain.Entitys;

namespace Application.Interfaces.ICategory
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> findAllCategory();
        public Task<Category> findCategoryById(int categoryId);
    }
}
