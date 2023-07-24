using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RBController : ControllerBase
    {
        private readonly DataContext _context;

        public RBController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostRetroBonus([FromBody] List<RetroBonusHeader> retroBonuses)
        {
            try
            {
                foreach (var retroBonus in retroBonuses)
                {
                    // Ensure related entities are tracked by EF Core
                    _context.Attach(retroBonus);

                    // Save the RetroBonusHeader
                    _context.RetroBonusHeaders.Add(retroBonus);

                    // Save the RetroBonusDetails
                    if (retroBonus.Products != null)
                    {
                        foreach (var product in retroBonus.Products)
                        {
                            _context.RetroBonusDetails.Add(product);
                        }
                    }

                    // Save the RetroBonusPlanRanges
                    if (retroBonus.PlanRanges != null)
                    {
                        foreach (var planRange in retroBonus.PlanRanges)
                        {
                            _context.RetroBonusPlanRanges.Add(planRange);
                        }
                    }
                }

                // Commit changes to the database
                await _context.SaveChangesAsync();

                return Ok("Data successfully saved to the database.");
            }

           catch (DbUpdateException ex)
    {
        // Log the exception (you can use a logger or print the error to the console)
        Console.WriteLine($"Error occurred while saving data: {ex.Message}");

        // Check if there's an inner exception (root cause of the error)
        if (ex.InnerException != null)
        {
            // Log or display the inner exception message as well
            Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
        }

        // Return a more detailed error message in the response
        return StatusCode(500, "Error occurred while saving data to the database. Please check the logs for more information.");
    }
        }

    }
}
