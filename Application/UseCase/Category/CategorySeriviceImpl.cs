using Application.Dtos.Category;
using Application.Interfaces;
using AutoMapper;
using Domain.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.UseCase
{
    public class CategorySeriviceImpl : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategorySeriviceImpl> _logger;
        private readonly IMapper _mapper;

        public CategorySeriviceImpl(ICategoryRepository categoryRepository, ILogger<CategorySeriviceImpl> logger, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> findAllCategory()
        {
            _logger.LogInformation("Init - findAllCategory");
            List<CategoryDTO> dTOCategoryResponses = new List<CategoryDTO>();
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
                    dTOCategoryResponses.Add(_mapper.Map<CategoryDTO>(category));
                }
            }
            _logger.LogInformation("Out - findAllCategory");
            return dTOCategoryResponses;
        }
    }
}
