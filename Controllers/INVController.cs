using Marlin.sqlite.Data;
using Marlin.sqlite.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class INVController : ControllerBase
    {
        private readonly DataContext _context;

        public INVController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CreateInvoice([FromBody] List<InvoiceData> invoiceDataList)
        {
            try
            {
                foreach (var invoiceData in invoiceDataList)
                {
                    var invoiceHeader = new InvoiceHeader
                    {
                        OrderID = invoiceData.OrderID,
                        InvoiceID = invoiceData.InvoiceID,
                        Date = invoiceData.Date,
                        Number = decimal.TryParse(invoiceData.Number, out decimal number) ? number : (decimal?)null,
                        Amount = decimal.TryParse(invoiceData.Amount, out decimal amount) ? amount : (decimal?)null,
                        StatusID = null,
                        WaybillNumber = null,
                        PaymentDate = DateTimeOffset.MinValue
                    };

                    _context.InvoiceHeaders.Add(invoiceHeader);
                    _context.SaveChanges();

                    foreach (var product in invoiceData.Products)
                    {
                        var invoiceDetail = new InvoiceDetail
                        {
                            InvoiceHeaderID = invoiceHeader.InvoiceID,
                            ProductID = product.Barcode,
                            Unit = product.Unit,
                            Quantity = decimal.TryParse(product.Quantity, out decimal quantity) ? quantity : (decimal?)null,
                            Price = decimal.TryParse(product.Price, out decimal price) ? price : (decimal?)null,
                            Amount = decimal.TryParse(product.Amount, out decimal productAmount) ? productAmount : (decimal?)null
                        };

                        _context.InvoiceDetails.Add(invoiceDetail);
                    }

                    _context.SaveChanges();
                }

                return Ok("Invoices created successfully.");
            }
            catch (Exception ex)
            {
                // Inspect the inner exception for more details
                var errorMessage = $"Failed to create invoices: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $" Inner Exception: {ex.InnerException.Message}";
                }

                return BadRequest(errorMessage);
            }
        }

    }
}
