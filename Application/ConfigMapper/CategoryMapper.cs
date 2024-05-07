using Application.Dtos.Category;
using Domain.Entitys;

namespace Application.Mappers
{
    public class CategoryMapper
    {
        public static DTOCategoryResponse mapperToDTOCategoryResponse(Category category)
        {
            DTOCategoryResponse dTOCategoryResponse = new DTOCategoryResponse();
           // dTOCategoryResponse.CategoryId = category.CategoryId;
            dTOCategoryResponse.Name = category.Name;

            return dTOCategoryResponse;
        }
    }
}
