using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueFrontController : ControllerBase
    {
        private readonly DataContext _context;

        public CatalogueFrontController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{AccountID}/{CategoryID}")]
        public IActionResult GetData(string AccountID, string CategoryID)
        {
            try
            {
                var query = @"
                    WITH tmpPriceList AS (
                        SELECT pl.""AccountID"" AS ""AccountID"", pl.""ProductID"" AS ""ProductID"", MAX(pl.""Date"") AS ""Date""
                        FROM public.""PriceList"" AS pl
                        INNER JOIN public.""ProductsByCategories"" pbc ON pl.""ProductID"" = pbc.""ProductID"" AND pl.""AccountID"" = pbc.""AccountID"" AND pbc.""CategoryID"" = @CategoryID
                        WHERE pl.""AccountID"" = @AccountID
                        GROUP BY pl.""AccountID"", pl.""ProductID""
                    )
                   SELECT
                        c.""Id"" AS ""Id"",
                        c.""AccountID"" AS ""AccountID"", -- Include the Id column here
                        b.""Barcode"" AS ""Barcode"",
                        c.""ProductID"" AS ""ProductID"",
                        c.""Name"" AS ""Product"",
                        c.""Unit"" AS ""Unit"",
                        c.""Status"" AS ""Status"",
                        pl.""Price"" AS ""Price"",
                        pl.""Price"" AS ""LastOrderPrice"",
                        pl.""Date"" AS ""LastChangeDate""
                    FROM public.""Catalogues"" c
                    LEFT JOIN public.""Barcodes"" b ON c.""ProductID"" = b.""ProductID"" AND c.""AccountID"" = b.""AccountId""
                    INNER JOIN public.""ProductsByCategories"" pbc ON c.""ProductID"" = pbc.""ProductID"" AND c.""AccountID"" = pbc.""AccountID"" AND pbc.""CategoryID"" = @CategoryID
                    LEFT JOIN public.""PriceList"" pl ON c.""ProductID"" = pl.""ProductID"" AND c.""AccountID"" = pl.""AccountID""
                    INNER JOIN tmpPriceList tpl ON pl.""ProductID"" = tpl.""ProductID"" AND pl.""AccountID"" = tpl.""AccountID"" AND pl.""Date"" = tpl.""Date""
                    WHERE c.""AccountID"" = @AccountID";

                var parameters = new[]
                {
                    new Npgsql.NpgsqlParameter("@CategoryID", CategoryID),
                    new Npgsql.NpgsqlParameter("@AccountID", AccountID)
                };

                var data = _context.Set<temTable>().FromSqlRaw(query, parameters).ToList();

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
