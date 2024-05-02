using Application.Dtos;

namespace Application.Interfaces.ICategory
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> findAllCategory();
    }
}
