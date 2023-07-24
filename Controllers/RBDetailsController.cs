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
    public class RetroBonusController : ControllerBase
    {
        private readonly DataContext _context;

        public RetroBonusController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{AccountID}")]
        public IActionResult GetData(string AccountID)
        {
            try
            {
                var query = @"
                    WITH tmpPurchaseOrders AS (
                        SELECT OH.""AccountID"", IH.""Date"", ID.""ProductID"" as ""Barcode"", ID.""Amount""
                        FROM public.""InvoiceHeaders"" as IH
                        JOIN public.""OrderHeaders"" as OH
                            ON IH.""OrderID"" = OH.""OrderID""
                        JOIN public.""InvoiceDetails"" as ID
                            ON IH.""InvoiceID"" = ID.""InvoiceHeaderID""
                    )
                    SELECT
                        RBD.""Id"",
                        RBD.""RetroBonusID"",
                        RBD.""Barcode"",
                        C.""Name"" as ""Product"",
                        GREATEST(RBD.""MinimalPercent"", RBD.""PlanPercent"", RBD.""ManufacturerPercent"") as ""RetroPercent"",
                        SUM(PUR.""Amount"") as ""PurchaseAmount"",
                        MAX(PS.""Quantity"") as ""Stock""
                    FROM public.""RetroBonusDetails"" as RBD
                    JOIN public.""RetroBonusHeaders"" as RB
                        ON RBD.""RetroBonusID"" = RB.""RetroBonusID""
                    LEFT JOIN public.""Barcodes"" as B
                        ON RBD.""Barcode"" = B.""Barcode""
                    LEFT JOIN public.""Catalogues"" as C
                        ON C.""ProductID"" = B.""ProductID""
                    LEFT JOIN tmpPurchaseOrders as PUR
                        ON RBD.""Barcode"" = PUR.""Barcode"" AND RB.""AccountID"" = PUR.""AccountID""
                            AND PUR.""Date"" BETWEEN RB.""StartDate"" AND (CASE WHEN RB.""EndDate"" IS NULL THEN NOW() ELSE RB.""EndDate"" END)
                    LEFT JOIN public.""ProductsStocks"" as PS
                        ON RBD.""Barcode"" = PS.""Barcode"" AND RB.""AccountID"" = PS.""AccountID""
                    WHERE RB.""AccountID"" = @AccountID
                    GROUP BY RBD.""Id"", RBD.""RetroBonusID"", RBD.""Barcode"", C.""Name"", GREATEST(RBD.""MinimalPercent"", RBD.""PlanPercent"", RBD.""ManufacturerPercent"")";

                var parameter = new Npgsql.NpgsqlParameter("@AccountID", AccountID);

                var data = _context.RetroBonusResults.FromSqlRaw(query, parameter).ToList();

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
