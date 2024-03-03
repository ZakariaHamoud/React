using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Items : ControllerBase
    {
        private readonly StoreDbContext _context;

        public Items(StoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet]
        public IActionResult GetItems()
        {
            var items = _context.DbItems.ToListAsync(); 
            return Ok(items); 
        }
    }
}
