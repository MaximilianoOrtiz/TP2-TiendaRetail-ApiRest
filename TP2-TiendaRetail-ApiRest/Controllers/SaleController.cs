using Application.Dtos.ApiError;
using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using Application.Exceptions;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP2_TiendaRetail_ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        [Route("[controller]")]
        public async Task<ActionResult<SaleResponse>> saveSale([FromBody] SaleRequest saleRequest)
        {
            try
            {
                SaleResponse saleResponse = await _saleService.saveSale(saleRequest);
                return new JsonResult(saleResponse) { StatusCode = 201 };
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
