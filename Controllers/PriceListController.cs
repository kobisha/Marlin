using Marlin.sqlite.Data;
using Marlin.sqlite.Filter;
using Marlin.sqlite.Helper;
using Marlin.sqlite.Models;
using Marlin.sqlite.Services;
using Marlin.sqlite.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceListController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUriService _uriService;

        public PriceListController(DataContext context, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;
        }
        [HttpPost]
        public IActionResult ImportData([FromBody] List<PriceList> priceListData)
        {
            if (priceListData == null || !priceListData.Any())
            {
                return BadRequest(new { error = "No data provided." });
            }

            try
            {
                _context.PriceList.AddRange(priceListData);
                _context.SaveChanges();

                return Ok(new { message = "Data imported successfully" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { error = "An error occurred while importing data.", message = e.Message });
            }
        }

        

    [HttpGet]
        public async Task<IActionResult> GetOrders([FromQuery] PaginationFilter filter)
        {
            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await _context.PriceList
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();
            var totalRecords = await _context.PriceList.CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<PriceList>(pagedData, validFilter, totalRecords, _uriService, route);
            return Ok(pagedReponse);
        }

        


    }
}
