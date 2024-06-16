using Application.Dtos.ApiError;
using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using Application.Exceptions;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace TP2_TiendaRetail_ApiRest.Controllers
{
    [Route("api/")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        /// <summary>
        /// Permite ingresar una nueva venta al sistema.
        /// </summary>
        /// <remarks>
        /// Se debe proporcionar la información de la venta a través del cuerpo de la solicitud en formato JSON.
        /// </remarks>
        /// <param name="saleRequest">Datos de la venta a ser registrada.</param>
        /// <response code="201">Venta registrada con éxito.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        [HttpPost]
        [Route("[controller]")]
        public async Task<ActionResult<SaleResponse>> PostSale([FromBody] SaleRequest saleRequest)
        {
            try
            {
                SaleResponse saleResponse = await _saleService.SaveSaleAsync(saleRequest);
                return new JsonResult(saleResponse) { StatusCode = 201 };
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
            catch (CustomExceptionBadRequest ex)
            {
                return BadRequest(new ApiError(ex.Message));
            }
        }

        /// <summary>
        /// Obtiene una venta por su ID.
        /// </summary>
        /// <remarks>
        /// Devuelve los detalles de una venta específica identificada por su ID.
        /// </remarks>
        /// <param name="id">ID de la venta a recuperar.</param>
        /// <response code="200">Éxito al recuperar la venta.</response>
        /// <response code="404">Venta no encontrada.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        /// <returns>Detalles de la venta especificada.</returns>
        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<SaleResponse>> GetSaleById(int id)
        {
            try
            {
                SaleResponse saleResponse = await _saleService.FindSaveByIdAsync(id);
                if (saleResponse == null)
                {
                    return NotFound(new ApiError("No existe una venta asociada al Id: " + id));
                }
                return Ok(saleResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
        }

        /// <summary>
        /// Obtiene un listado de ventas.
        /// </summary>
        /// <remarks>
        /// Recupera un resumen de las ventas realizadas, con opción de filtrado por fecha
        /// </remarks>
        /// <param name="from">Fecha de inicio del rango de búsqueda en formato de aaaa/mm/dd.</param>
        /// <param name="to">Fecha de fin del rango de búsqueda en formato de aaaa/mm/dd.</param>
        /// <response code="200">Éxito al recuperar las ventas.</response>
        /// <response code="400">Solicitud incorrecta.</response>
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetFilterByDateTime([FromQuery] DateTime from, [FromQuery] DateTime to)
        {

            try
            {

                List<SaleGetResponse> saleGetResponse = await _saleService.GetFilterByDateTimeAsync(from, to);

                int cant = saleGetResponse.Count;

                return Ok(saleGetResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
            catch (CustomExceptionBadRequest ex)
            {
                return BadRequest(new ApiError(ex.Message));
            }
        }
    }
}
