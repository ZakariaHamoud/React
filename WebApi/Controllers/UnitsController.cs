using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public UnitsController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Units
        [HttpGet]
        public IActionResult GetUnits()
        {
            var units = _context.DbUnits.ToListAsync();
            return Ok(units);
        }
    }
}
