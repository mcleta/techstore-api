using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechStore.Models;
using TechStore.Services;

namespace TechStore.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly TSServices _tsServices;

        public OrderController(TSServices tsServices) =>
            _tsServices = tsServices;

        [HttpGet]
        public async Task<List<Order>> GetOrders() =>
            await _tsServices.GetAllOrdersAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Order>> GetOrder(string id)
        {
            var user = await _tsServices.GetOneOrderAsync(id);

            if (user is null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> PostOrder(Order newOrder)
        {
            var date = DateTime.Now;

            newOrder.Date = date.ToString();

            await _tsServices.AddOrder(newOrder);

            return Ok(newOrder);
        }
    }
}
