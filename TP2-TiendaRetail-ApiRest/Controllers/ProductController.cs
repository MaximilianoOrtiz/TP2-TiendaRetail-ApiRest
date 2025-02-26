﻿using Application.Dtos;
using Application.Dtos.ApiError;
using Application.Dtos.Product.Response;
using Application.Exceptions;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace TP2_TiendaRetail_ApiRest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISaleProductService _saleProductService;

        public ProductController(IProductService productService, ISaleProductService saleProductService)
        {
            _productService = productService;
            _saleProductService = saleProductService;
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
        /// <response code="409">Conflicto.</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns>Una lista de productos.</returns>
        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<ProductoGetResponse>> GetProductbyFilters([FromQuery] int[] categories,
                                                                                  [FromQuery] string? name,
                                                                                  [FromQuery] int limit = 0,
                                                                                  [FromQuery] int offset = 0)
        {
            try
            {
                List<ProductoGetResponse> listProduct = await _productService.FindProductByCategoryIdAndNameAsync(categories, name, limit, offset);

                return Ok(listProduct);
            }
            catch (DbException ex)
            {
                return StatusCode(500, new ApiError("Ocurrió un error al consultar la base de datos. Error --> " + ex.Message));
            }
        }

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <remarks>
        /// Permite la creación de un nuevo producto en el sistema.
        /// </remarks>
        /// <param name="productRequest"></param>
        /// <response code="201">Producto creado con éxito</response>Solicitud incorrecta.
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="409">Conflicto, el producto ya existe.</response>
        /// <response code="500">Ocurrio una falla en el servidor</response>
        /// <returns></returns>
        [HttpPost]
        [Route("[controller]")]
        public async Task<ActionResult<ProductResponse>> PostProduct([FromBody] ProductRequest productRequest)
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
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos. Error --> " + ex.Message)) { StatusCode = 500 };
            }
            catch (CustomExceptionBadRequest ex)
            {
                return BadRequest(new ApiError(ex.Message));
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
        public async Task<ActionResult<ProductResponse>> GetProductById(Guid id)
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
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos. Error --> " + ex.Message)) { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        ///  <remarks>
        /// Permite la actualización de los detalles de un producto específico.
        /// </remarks>
        /// <param name="Id">El ID del producto que se va a actualizar.</param>
        /// <param name="productRequest">Los detalles actualizados del producto en el cuerpo de la solicitud.</param>
        /// <returns>Una respuesta que indica el resultado de la actualización del producto.</returns>
        /// <response code="200">Producto actualizado con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <response code="404">Producto no encontrado.</response>
        /// <response code="409">Conflicto al actualizar el producto..</response>
        [HttpPut]
        [Route("[controller]/{Id}")]
        public async Task<ActionResult<ProductResponse>> PutProduct([FromBody] ProductRequest productRequest, Guid Id)
        {
            try
            {
                ProductResponse productResponse = await _productService.UpdateProductAsync(productRequest, Id);

                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {Id}"));
                }
                return Ok(productResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos. Error --> " + ex.Message)) { StatusCode = 500 };
            }
            catch (CustomExceptionBadRequest ex)
            {
                return BadRequest(new ApiError(ex.Message));
            }
            catch (CustomExceptionConflict ex)
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
        [Route("[controller]/{Id}")]
        public async Task<ActionResult<ProductResponse>> DeleteProduct(Guid Id)
        {
            try
            {
                if (await _saleProductService.HasProductAssociatedAsync(Id))
                {
                    return Conflict(new ApiError("No se puede eliminar un producto que este asociado a una venta.  ProductId: " + Id));
                }

                ProductResponse productResponse = await _productService.DeleteProductAsync(Id);

                if (productResponse == null)
                {
                    return NotFound(new ApiError($"No se encontro el producto con ID: {Id}"));
                }
                return Ok(productResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos. Error --> " + ex.Message)) { StatusCode = 500 };
            }
        }
    }
}
