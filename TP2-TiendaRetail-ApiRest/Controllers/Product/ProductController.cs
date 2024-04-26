using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP2_TiendaRetail_ApiRest.Controllers.Product
{
    [Route("api/")]
    [ApiController]
    public class ProductController : Controller
    {
        // GET: ProductCon
        [HttpGet]
        [Route("[controller]")]
        public ActionResult findProductbyFilters([FromQuery] List<int> categorys, string name, int limit, int  offset)
        {
            return View(); 
        }

       
    }
}
