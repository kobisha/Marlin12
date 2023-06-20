﻿using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersByAccountFrontController : ControllerBase
    {
        private readonly DataContext _context;

        public OrdersByAccountFrontController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{AccountID}")]
        public IActionResult GetData(string AccountID)
        {
            try
            {
                var query = @"
                    SELECT
                            oh.""Id"",
                            oh.""AccountID"",

                            oh.""OrderID"",

                             TO_CHAR(oh.""Date"", 'YYYY-MM-DD HH:MI:SS') as ""Date"",

                            oh.""Number"",

                            oh.""ReceiverID"" AS ""VendorID"",

                            ac.""Name""  AS ""Vendor"",

                            s.""Name"" AS ""Shop"",

                            CAST(oh.""Amount"" AS decimal) as ""Amount"",

                            st.""StatusName"" AS ""Status"",

                            TO_CHAR( (Cast(oh.""Date"" as Date) + INTERVAL '3 days'), 'YYYY-MM-DD HH:MI:SS') AS ""Scheduled""

                        FROM public.""OrderHeaders"" oh

                        LEFT JOIN public.""Shops"" s ON oh.""ShopID"" = s.""ShopID""

                        LEFT JOIN public.""OrderStatus"" st ON oh.""StatusID"" = st.""Id""

                        LEFT JOIN public.""Accounts"" ac ON oh.""ReceiverID""  = ac.""AccountID""

                        where oh.""AccountID"" = @AccountID";

                var parameters = new[]
                {
                    
                    new Npgsql.NpgsqlParameter("@AccountID", AccountID)
                };

                var data = _context.Set<OrderFront>().FromSqlRaw(query, parameters).ToList();

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
