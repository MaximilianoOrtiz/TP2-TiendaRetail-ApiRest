using Application.Dtos;
using Application.Dtos.ApiError;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP2_TiendaRetail_ApiRest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        /// <summary>
        /// Lista todas las categorias
        /// </summary>
        /// <response code="200">Éxito al recuperar las categorias</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult> GetAllCategory()
        {
            try
            {
                List<CategoryDTO> listCategoryResponse = await _categoryService.FindAllCategoryAsync();

                if (listCategoryResponse.Count == 0)
                {
                    return NotFound(new ApiError("No se encontraron categorías."));
                }

                return Ok(listCategoryResponse);
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ApiError("Ocurrió un error al consultar la base de datos.  Error --> " + ex.Message));
            }

        }

        [HttpGet]
        [Route("prueba")]
        public IActionResult Get()
        {
            var tutorials = new List<object>
            {
                new
                {
                    id = "html",
                    title = "HTML: Descripcion de HTML",
                    text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Provident error ut,velit commodi harum a explicabo? Velit voluptatibus vero quos ex molestias.",
                    listItem = new [] { "Etiquetas (tags)", "Atributos", "Elementos" }
                },
                new
                {
                    id = "css",
                    title = "CSS: Descripcion de CSS",
                    text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Provident error ut,velit commodi harum a explicabo? Velit voluptatibus vero quos ex molestias.",
                    listItem = new [] { "Etiquetas (tags)", "Atributos", "Elementos" }
                },
                new
                {
                    id = "javascript",
                    title = "Javascript: Descripcion de Javascript",
                    text = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Provident error ut,velit commodi harum a explicabo? Velit voluptatibus vero quos ex molestias.",
                    listItem = new [] { "Etiquetas (tags)", "Atributos", "Elementos" }
                }
            };

            return Ok(tutorials);
        }

    }
}
