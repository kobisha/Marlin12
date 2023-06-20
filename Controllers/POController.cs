using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Marlin.sqlite.Data;
using Marlin.sqlite.JsonModels;
using Marlin.sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Marlin.sqlite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class POController : ControllerBase
    {
        private readonly DataContext _context;

        public POController(DataContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CreateOrder([FromBody] List<OrderHeaders> orders)
        {
            try
            {
                foreach (var order in orders)
                {
                    // Process the order and its associated details
                    var orderHeadersData = new OrderHeaders
                    {
                        AccountID = order.AccountID,
                        OrderID = order.OrderID,
                        Date = order.Date,
                        Number = order.Number,
                        SenderID = order.SenderID,
                        ReceiverID = order.ReceiverID,
                        ShopID = order.ShopID,
                        Amount = order.Amount,
                        StatusID = 1,
                        SendStatus = 1
                    };

                    // Save the orderHeadersData to the database
                    _context.OrderHeaders.Add(orderHeadersData);


                    foreach (var product in order.Products)
                    {
                        var orderDetailsData = new OrderDetails
                        {
                            OrderHeaderID = product.OrderHeaderID,
                            ProductID = product.ProductID,
                            Unit = product.Unit,
                            Quantity = product.Quantity,
                            Price = product.Price,
                            Amount = product.Amount,
                            ReservedQuantity = 0
                        };

                        // Save the orderDetailsData to the database
                        _context.OrderDetails.Add(orderDetailsData);

                    }

                    var orderStatusHistory = new OrderStatusHistory
                    {
                        OrderID = order.OrderID,
                        Date = DateTime.Now,
                        StatusID = orderHeadersData.StatusID,
                    };
                    _context.OrderStatusHistory.Add(orderStatusHistory);
                
            }
                _context.SaveChanges();
                return Ok(new { message = "Orders created successfully" });
            }
            catch (Exception e)
            {
                var errorMessage = "An error occurred while saving the entity changes.";
                if (e.InnerException != null)
                {
                    errorMessage += " Inner Exception: " + e.InnerException.Message;
                }

                return BadRequest(new { error = errorMessage });
            }
        }


    }
}
