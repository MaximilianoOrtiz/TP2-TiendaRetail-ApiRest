
using Application.Dtos.Category;

namespace Application.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<DTOCategoryResponse>> findAllCategory();
    }
}
