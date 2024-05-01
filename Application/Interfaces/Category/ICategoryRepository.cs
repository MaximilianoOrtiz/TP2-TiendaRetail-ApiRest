using Domain.Entitys;

namespace Application.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> findAllCategory();
       public Task<Category> findCateegoryById(int categoryId);
    }
}
