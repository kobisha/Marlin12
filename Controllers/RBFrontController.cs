using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Marlin.sqlite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RBFrontController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUriService _uriService;



        public RBFrontController(DataContext context, IUriService uriService)
        {
            _context = context;
            _uriService = uriService;


        }
        [HttpGet]
        public IActionResult GetData()
        {
            try
            {
                var query = @"
            SELECT
    MIN(""Id"") as ""Id"",
    ""AccountID"",
    ""RetroBonusID"",
    ""DocumentNo"" ,
    ""SupplierID"",
    ""StartDate"",
    ""EndDate"",
    ""Status"",
    ""Condition"",
    ""PlanAmount"",
    greatest(""MinimalPercent"", ""PlanPercent"", ""ManufacturerPercent"") as ""RetroPercent""
FROM public.""RetroBonusHeaders""
GROUP BY
    ""AccountID"",
    ""RetroBonusID"",
    ""DocumentNo"",
    ""SupplierID"",
    ""StartDate"",
    ""EndDate"",
    ""Status"",
    ""Condition"",
    ""PlanAmount"",
    greatest(""MinimalPercent"", ""PlanPercent"", ""ManufacturerPercent"")";

                var data = _context.Set<RBFront>().FromSqlRaw(query).ToList();

                // Transform the data to include "MinimalPercent"
                var transformedData = data.Select(item => new
                {
                    item.Id,
                    item.AccountID,
                    item.RetroBonusID,
                    item.DocumentNo,
                    item.SupplierID,
                    item.StartDate,
                    item.EndDate,
                    item.Status,
                    item.Condition,
                    item.PlanAmount,
                    item.RetroPercent,
                    // Include the "MinimalPercent" property if needed
                    //MinimalPercent = GetMinimalPercentFromSomewhere()
                }).ToList();

                var response = new
                {
                    Data = transformedData
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
