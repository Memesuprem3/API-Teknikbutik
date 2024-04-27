using API_Teknikbutik.Services;
using API_Teknikbutiken_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Teknikbutik.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ITeknikButik<Order> _teknikButik;
        
        public OrderController(ITeknikButik<Order> teknikbutik)
        {
            _teknikButik = teknikbutik;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> CreateNewOrder(Order NewOrder)
        {
            try
            {
                if (NewOrder == null)
                {
                    return BadRequest($"Order not found mf");
                }
                var CreatedOrder = await _teknikButik.Add(NewOrder);
                return CreatedAtAction(nameof(Getorder),
                    new {id =CreatedOrder.OrderId},CreatedOrder);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error to post data to database");
            }
        }
        public async Task<ActionResult<Order>> Getorder(int id)
        {
            return null;
        }
    }
}
