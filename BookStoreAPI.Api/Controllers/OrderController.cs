using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class OrderController: ApiControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
        public IActionResult CreateOrder(string title, string mail)
        {
            var order = _orderService.OrderBook(title, mail);

            return Created("/", order);
        }
    }
}
