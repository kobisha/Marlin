using System;
using System.Linq;
using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusResultFrontController : ControllerBase
    {
        private readonly DataContext _context;

        public StatusResultFrontController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderStatus(string orderId)
        {
            try
            {
                var query = @"
                    SELECT osh.""Id"",osh.""OrderID"", osh.""Date"", os.""StatusName""
                    FROM public.""OrderStatusHistory"" as osh
                    JOIN public.""OrderStatus"" as os ON osh.""StatusID"" = os.""StatusID""
                    WHERE osh.""OrderID"" = @OrderID";

                var parameters = new[]
                {
                    new Npgsql.NpgsqlParameter("@OrderID", orderId)
                };

                var orderStatus = _context.Set<OrderStatusResult>().FromSqlRaw(query, parameters).ToList();

                var response = new
                {
                    Data = orderStatus
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
