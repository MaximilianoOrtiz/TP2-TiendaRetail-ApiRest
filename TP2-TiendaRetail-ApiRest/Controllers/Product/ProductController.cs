using Application.Dtos.ApiError;
using Application.Dtos.Product;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.Common;

namespace TP2_TiendaRetail_ApiRest.Controllers.Product
{
   
    [Route("api/")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Obtiene una lista de productos
        /// </summary>
        /// <param name="categorys">Filtrar productos por categorías. Es posible filtrar por 1 o más categorias. Filtro opcional</param>
        /// <param name="name">Filtrar productos por nombre. Es posible filtrar por nombres incompletosn</param>
        /// <param name="limit">Limita el número de productos devueltos</param>
        /// <param name="offset">Número de productos a omitir antes de empezar a devolver los resultados</param>
        /// <response code="200">Éxito al recuperar los productos</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns></returns>
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<List<ProductoGetResponse>>> findProductbyFilters([FromQuery] int[] categorys, string name, [DefaultValue(0)] int limit, [DefaultValue(0)] int offset)
        {
            try
            {
                var listProduct = await _productService.findProductbyCategoryIdAndName(categorys, name, limit, offset);
                return Ok(listProduct);
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message));
            }

        }
    }
}
