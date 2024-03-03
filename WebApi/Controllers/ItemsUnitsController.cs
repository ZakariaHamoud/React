using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using System.Linq;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsUnitsController : ControllerBase
    {
        private readonly StoreDbContext _context;

        public ItemsUnitsController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ItemUnit
        [HttpGet]
        public IActionResult GetItemUnit()
        {
            var itemUnits = _context.DbItemsUnits
                .Include(iu => iu.DbItems)
                .Include(iu => iu.DbUnits)
                .ToListAsync();
            return Ok(itemUnits);
        }

    }
}
