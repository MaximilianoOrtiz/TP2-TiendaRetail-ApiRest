using Application.Dtos;
using Application.Dtos.ApiError;
using Application.Dtos.Product;
using Application.Exceptions;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.Common;

namespace TP2_TiendaRetail_ApiRest.Controllers
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
        /// Obtiene una lista de productos.
        /// </summary>
        /// <remarks>
        /// Recupera una lista de productos disponibles, con opciones de filtrado.
        /// </remarks>
        /// <param Name="categories">Filtrar productos por categorías. Es posible filtrar por 1 o más categorias. Filtro opcional</param>
        /// <param Name="name">Filtrar productos por nombre. Es posible filtrar por nombres incompletos</param>
        /// <param Name="limit">Limita el número de productos devueltos.</param>
        /// <param Name="offset">Número de productos a omitir antes de empezar a devolver los resultados.</param>
        /// <response code="200">Éxito al recuperar las categorias</response>
        /// <response code="409">Conflicto.</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns>Una lista de productos.</returns>
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<ProductoGetResponse>> findProductbyFilters([FromQuery] int[] categorys,
                                                                                  [FromQuery] string name,
                                                                                  [FromQuery][DefaultValue(0)] int limit,
                                                                                  [FromQuery][DefaultValue(0)] int offset)
        {
            try
            {
                List<ProductoGetResponse> listProduct = await _productService.FindProductByCategoryIdAndNameAsync(categorys, name, limit, offset);
                if (listProduct.Count() == 0)
                {
                    return NotFound(new ApiError("No se encontraron productos"));
                }
                return Ok(listProduct);
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message));
            }
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <remarks>
        ///Permite la creación de un nuevo producto en el sistema.
        /// </remarks>
        /// <param Name="productRequest"></param>
        /// <response code="201">Producto creado con éxito</response>Solicitud incorrecta.
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="409">Conflicto, el producto ya existe.</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns></returns>
        [HttpPost]
        [Route("[controller]")]
        public async Task<ActionResult<ProductResponse>> createProduct([FromBody] ProductRequest productRequest)
        {
            try
            {
                if (await _productService.ExistProductByEqualNameAsync(productRequest.Name))
                {
                    return Conflict(new ApiError("No puede existir dos productos con el mismo nombre en la base"));
                }
                ProductResponse productResponse = await _productService.SaveProductAsync(productRequest);

                return new JsonResult(productResponse) { StatusCode = 201 };
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Obtiene detalles de un producto específico.
        /// </summary>
        /// <remarks>
        /// Recupera los detalles de un producto por su ID único.
        /// </remarks>
        /// <param Name="id">ID único del producto.</param>
        /// <returns>Detalles del producto.</returns>
        /// <response code="200">Éxito al recuperar los detalles del producto.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<ProductResponse>> getProductById(Guid id)
        {
            try
            {
                ProductResponse productResponse = await _productService.FindProductbyIdAsync(id);
                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {id}"));
                }
                return Ok(productResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        ///  <remarks>
        /// Permite la actualización de los detalles de un producto específico.
        /// </remarks>
        /// <param Name="id">El ID del producto que se va a actualizar.</param>
        /// <param Name="productRequest">Los detalles actualizados del producto en el cuerpo de la solicitud.</param>
        /// <returns>Una respuesta que indica el resultado de la actualización del producto.</returns>
        /// <response code="200">Producto actualizado con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="404">Producto no encontrado.</response>
        /// <response code="409">Conflicto al actualizar el producto..</response>
        [HttpPut]
        [Route("[controller]/{productId}")]
        public async Task<ActionResult<ProductResponse>> updateProduct([FromBody] ProductRequest productRequest, Guid productId)
        {
            try
            {
                ProductResponse productResponse = await _productService.UpdateProductAsync(productRequest, productId);

                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {productId}"));
                }
                return Ok(productResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
            catch (CustomException ex)
            {
                return Conflict(new ApiError(ex.Message));
            }
        }

        /// <summary>
        /// Elimina un producto específico.
        /// </summary>
        ///  <remarks>
        /// Permite la eliminación de un producto del sistema usando su ID.
        /// </remarks>
        /// <param Name="id">El ID del producto que se va a eliminar.</param>
        /// <returns>Una respuesta que indica el resultado de la eliminación del producto.</returns>
        /// <response code="200">Producto eliminado con éxito.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpDelete]
        [Route("[controller]/{productId}")]
        public async Task<ActionResult<ProductResponse>> deleteProduct(Guid productId)
        {
            try
            {
                ProductResponse productResponse = await _productService.DeleteProductAsync(productId);

                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {productId}"));
                }
                return Ok(productResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
            catch (CustomException ex)
            {
                return Conflict(new ApiError(ex.Message));
            }
        }
    }
}
