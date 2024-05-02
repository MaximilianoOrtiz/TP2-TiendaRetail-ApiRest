using Aplication.Dtos;
using Application.Dtos;
using Application.Dtos.ApiError;
using Application.Dtos.Product;
using Application.Exceptions;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Data.Common;
using System.Net;

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
        /// <param name="categories">Filtrar productos por categorías. Es posible filtrar por 1 o más categorias. Filtro opcional</param>
        /// <param name="name">Filtrar productos por nombre. Es posible filtrar por nombres incompletos</param>
        /// <param name="limit">Limita el número de productos devueltos.</param>
        /// <param name="offset">Número de productos a omitir antes de empezar a devolver los resultados.</param>
        /// <response code="200">Éxito al recuperar las categorias</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns>Una lista de productos.</returns>
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<ProductoGetResponse>> findProductbyFilters([FromQuery] int[] categorys, string name, [DefaultValue(0)] int limit, [DefaultValue(0)] int offset)
        {
            try
            {
                List<ProductoGetResponse> listProduct = await _productService.findProductbyCategoryIdAndName(categorys, name, limit, offset);
                if (listProduct.Count() == 0)
                {
                    return NotFound(new ApiError("No se encontraron productos"));
                }
                return Ok(new Result(listProduct, HttpStatusCode.OK));
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
        /// <param name="productRequest"></param>
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
                if (await _productService.existProductByEqualName(productRequest.Name))
                {
                    //Ahi que revisar esto chee
                    return Conflict(new ApiError("No puede existir dos productos con el mismo nombre en la base"));
                    //return new JsonResult(new ApiError("No puede existir dos productos con el mismo nombre en la base")) { StatusCode = 409 };
                    //return StatusCode(409, new ApiError("Hola"));
                }
                ProductResponse response = await _productService.saveProduct(productRequest);

                return new JsonResult(new Result(response, HttpStatusCode.Created)) { StatusCode = 201 };
            }
            catch (DbException ex)
            {

                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };

                // return StatusCode(500, new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message));
            }
        }

        /// <summary>
        /// Obtiene detalles de un producto específico.
        /// </summary>
        /// <remarks>
        /// Recupera los detalles de un producto por su ID único.
        /// </remarks>
        /// <param name="id">ID único del producto.</param>
        /// <returns>Detalles del producto.</returns>
        /// <response code="200">Éxito al recuperar los detalles del producto.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<ProductResponse>> getProductById(Guid id)
        {
            try
            {
                ProductResponse productResponse = await _productService.findProductbyId(id);
                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {id}"));
                }
                return Ok(new Result(productResponse, HttpStatusCode.OK));
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
        /// <param name="id">El ID del producto que se va a actualizar.</param>
        /// <param name="productRequest">Los detalles actualizados del producto en el cuerpo de la solicitud.</param>
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
                ProductResponse productResponse = await _productService.updateProduct(productRequest, productId);

                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {productId}"));
                }
                return Ok(new Result(productResponse, HttpStatusCode.OK));
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
        /// <param name="id">El ID del producto que se va a eliminar.</param>
        /// <returns>Una respuesta que indica el resultado de la eliminación del producto.</returns>
        /// <response code="200">Producto eliminado con éxito.</response>
        /// <response code="404">Producto no encontrado.</response>
        [HttpDelete]
        [Route("[controller]/{productId}")]
        public async Task<ActionResult<ProductResponse>> deleteProduct(Guid productId)
        {
            try
            {
                ProductResponse productResponse = await _productService.deleteProduct(productId);

                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {productId}"));
                }
                return Ok(new Result(productResponse, HttpStatusCode.OK));
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
