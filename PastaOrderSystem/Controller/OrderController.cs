﻿using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;
using WebApi.Service.Order;

namespace WebApi.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet("getAll")]
        public ActionResult<IEnumerable<OrderDto>> GetAll()
        {
            var orderList = _service.GetAll();
            return Ok(orderList);
        }

        [HttpGet("getById")]
        public async Task<ActionResult<OrderDto>> GetById([FromQuery] Guid id)
        {
            var order = await _service.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpGet("getWithJunction")]
        public async Task<ActionResult<OrderDto>> GetWithJunction([FromQuery] Guid orderId)
        {
            var order = _service.GetWithJunction(orderId);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost("add")]
        public ActionResult Add(OrderDto order)
        {
            _service.AddJunction(order);
            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] Guid id, OrderDto order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(order);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            var orderToDelete = await _service.GetByIdAsync(id);
            if (orderToDelete == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(orderToDelete);

            return NoContent();
        }
    }
}