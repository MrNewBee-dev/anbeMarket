using Anbe.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Anbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchApiController : ControllerBase
    {
        private readonly AnbeContext _anbeContext;

        public SearchApiController(AnbeContext anbeContext)
        {
            _anbeContext = anbeContext;
        }
        // GET: api/<SearchApiController>
        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                var term = HttpContext.Request.Query["term"].ToString();
                var list = await _anbeContext.Products.Where(p => p.ProductName.Contains(term)).Select(p => p.ProductName)
                    .ToListAsync();
                return Ok(list);
            }
            catch (Exception e)
            {

                return Content(e.Message);

            }

        }

        // GET api/<SearchApiController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


    }
}
