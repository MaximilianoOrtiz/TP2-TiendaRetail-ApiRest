﻿using Application.Dtos.ApiError;
using Application.Dtos.Sale.Request;
using Application.Dtos.Sale.Response;
using Application.Exceptions;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TP2_TiendaRetail_ApiRest.Controllers
{
    [Route("")]
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
        public async Task<ActionResult<SaleResponse>> SaveSale([FromBody] SaleRequest saleRequest)
        {
            try
            {
                SaleResponse saleResponse = await _saleService.SaveSale(saleRequest);
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


        [HttpGet]
        [Route("[controller]/{id}")]
        public async Task<ActionResult<SaleResponse>> FindSaleById(int id)
        {
            try
            {
                SaleResponse saleResponse = await _saleService.FindSaveById(id);
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

        [HttpGet]
        [Route("[controller]")]
        public async Task<ActionResult<List<SaleGetResponse>>> GetFilterByDateTime([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            try
            {
                List<SaleGetResponse> saleGetResponse = await _saleService.GetFilterByDateTime(from, to);
                if (saleGetResponse.IsNullOrEmpty())
                {
                    return NotFound(new ApiError("No existen ventas dentro del periodo indicado - Inicio : " + from + " Fin: " + to));
                }

                return Ok(saleGetResponse);
            }
            catch (DbException ex)
            {
                return new JsonResult(new ApiError("Ocurrió un error al consultar la base de datos -->  " + ex.Message)) { StatusCode = 500 };
            }
        }
    }
}
