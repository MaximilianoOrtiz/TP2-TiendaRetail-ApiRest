using Aplication.Dtos;
using Application.Dtos;
using Application.Dtos.ApiError;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Net;

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
        /// <param name="id">Id de la categoria</param>
        /// <response code="200">Éxito al recuperar las categorias</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult> getAllCategory(int id)
        {
            try
            {
                List<CategoryDTO> listCategoryResponse = await _categoryService.findAllCategory();

                if (listCategoryResponse.Count == 0)
                {
                    return NotFound(new ApiError("No se encontraron categorías."));
                }

                return Ok(new Result(listCategoryResponse, HttpStatusCode.OK));
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ApiError("Ocurrió un error al consultar la base de datos."));
            }

        }
    }
}
