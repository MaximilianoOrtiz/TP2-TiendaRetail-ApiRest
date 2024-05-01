
using Application.Dtos;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> findAllCategory();
    }
}
