using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesApiController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public SalesApiController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        public async Task<IActionResult> Search()
        {
            try
            {
                string term = HttpContext.Request.Query["Term"].ToString();
                var medicines = dbContext.Medicine.Where(s => s.Name.Contains(term)
                                       || s.GenericName.Contains(term))
                                        .Select(s=>s.Name);
                return Ok(await medicines.ToListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}