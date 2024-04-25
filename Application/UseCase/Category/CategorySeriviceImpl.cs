using Application.Dtos.Category;
using Application.Interfaces;
using Application.Mappers;
using Domain.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.UseCase
{
    public class CategorySeriviceImpl : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategorySeriviceImpl> _logger;

        public CategorySeriviceImpl(ICategoryRepository categoryRepository, ILogger<CategorySeriviceImpl> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<List<DTOCategoryResponse>> findAllCategory()
        {
            _logger.LogInformation("Init - findAllCategory");
            List<DTOCategoryResponse> dTOCategoryResponses = new List<DTOCategoryResponse>();
            List<Category> categorys = new List<Category>();

            categorys = await _categoryRepository.findAllCategory();
            _logger.LogInformation("categorys.Count: " + categorys.Count);

            if (categorys.Count != 0)
            {
                _logger.LogInformation("List Category: ");
                foreach (var item in categorys)
                    _logger.LogInformation(item.Name);

                foreach (Category category in categorys)
                {
                    dTOCategoryResponses.Add(CategoryMapper.mapperToDTOCategoryResponse(category));
                }
            }
            _logger.LogInformation("Out - findAllCategory");
            return dTOCategoryResponses;
        }
    }
}
