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

        public Task<List<DTOCategoryResponse>> findAllCategory()
        {
            _logger.LogInformation("Init - findAllCategory");
            List<Category> categorys = _categoryRepository.findAllCategory().Result;
            _logger.LogInformation("categorys.Count: " + categorys.Count);

            if (categorys != null && categorys.Count != 0)
            {
                _logger.LogInformation("List Category: ");
                foreach (var item in categorys)
                    _logger.LogInformation(item.Name);

                List<DTOCategoryResponse> dTOCategoryResponses = new List<DTOCategoryResponse>();

                foreach (Category category in categorys)
                {
                    dTOCategoryResponses.Add(CategoryMapper.mapperToDTOCategoryResponse(category));
                }

                _logger.LogInformation("Out - findAllCategory");
                return Task.FromResult(dTOCategoryResponses);
            }
            return null;
        }
    }
}
