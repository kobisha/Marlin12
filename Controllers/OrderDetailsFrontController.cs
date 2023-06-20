using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsFrontController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderDetailsFrontController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{OrderID}")]
        public IActionResult GetData(string OrderID)
        {
            try
            {
                var query = @"
            SELECT
                od.""Id"",
                od.""ProductID"",
                c.""Name"" AS ""Product"",
                b.""Barcode"" AS ""Barcode"",
                od.""Unit"",
                od.""Quantity"",
                od.""Price"",
                od.""Amount"",
                od.""ReservedQuantity"",
                case when od.""Quantity""- od.""ReservedQuantity"">0 then true else false end as ""RedStatus""
            FROM public.""OrderDetails"" od
            LEFT JOIN public.""Catalogues"" c ON od.""ProductID"" = c.""ProductID""
            LEFT JOIN public.""Barcodes"" b ON od.""ProductID"" = b.""ProductID""
            LEFT JOIN public.""OrderHeaders"" oh ON od.""OrderHeaderID"" = oh.""OrderID""
            WHERE od.""OrderHeaderID"" = @OrderID";

                var parameters = new[]
                {
            new Npgsql.NpgsqlParameter("@OrderID", OrderID)
        };

                var data = _context.Set<detailsFront>().FromSqlRaw(query, parameters).ToList();

                var response = new
                {
                    Data = data
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
