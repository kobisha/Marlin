using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateReservedQuantityController : ControllerBase
    {

        private readonly DataContext _context;

        public UpdateReservedQuantityController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("orderdetails")]
        public async Task<IActionResult> UpdateReservedQuantity([FromBody] List<OrderDetailsUpdate> orderDetailsUpdates)
        {
            foreach (var orderDetailsUpdate in orderDetailsUpdates)
            {
                var existingOrderDetails = await _context.OrderDetails.FirstOrDefaultAsync(o => o.OrderHeaderID == orderDetailsUpdate.OrderID);

                if (existingOrderDetails != null)
                {
                    existingOrderDetails.ReservedQuantity = orderDetailsUpdate.ReservedQuantity;
                }
            }

            await _context.SaveChangesAsync();

            return Ok();
        }







    }
}
