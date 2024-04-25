using Application.Dtos.Category;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP2_TiendaRetail_ApiRest.Controllers.Category
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
        /// <returns></returns>
        /// <response code="200"> Retorna todas las categorias </response>
        /// <response code="500"> Posible falla al consultar la base de datos</response>
        // GET: api/<CategoryController>
        [HttpGet]
        [Route("categorys")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<DTOCategoryResponse>>> getAllCategory()
        {
            try
            {
                var listCategoryResponse = await _categoryService.findAllCategory();

                if (listCategoryResponse.Count == 0)
                {
                    return NotFound("No se encontraron categorías.");
                }

                return Ok(new { data = listCategoryResponse });
            }
            catch (DbException ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error al consultar la base de datos", error = ex.Message });
            }
        }
    }
}
