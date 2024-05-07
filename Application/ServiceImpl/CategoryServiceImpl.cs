using Application.Dtos;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using Domain.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.UseCase
{
    public class CategoryServiceImpl : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryServiceImpl> _logger;
        private readonly IMapper _mapper;

        public CategoryServiceImpl(ICategoryRepository categoryRepository, ILogger<CategoryServiceImpl> logger, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> FindAllCategoryAsync()
        {
            _logger.LogInformation("Init - FindAllCategoryAsync");
            List<CategoryDTO> dTOCategoryResponses = new List<CategoryDTO>();
            List<Category> categorys = new List<Category>();

            categorys = await _categoryRepository.FindAllCategoryAsync();
            _logger.LogInformation("categorys.Count: " + categorys.Count);

            if (categorys.Count != 0)
            {
                foreach (Category category in categorys)
                {
                    dTOCategoryResponses.Add(_mapper.Map<CategoryDTO>(category));
                }
            }
            _logger.LogInformation("Out - FindAllCategoryAsync");
            return dTOCategoryResponses;
        }
    }
}
