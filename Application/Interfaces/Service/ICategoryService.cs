using Application.Dtos;

namespace Application.Interfaces.Service
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> FindAllCategoryAsync();
    }
}
