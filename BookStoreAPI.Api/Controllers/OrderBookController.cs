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
    public class OrderBookController: ApiControllerBase
    {
        private readonly IOrderBookService _orderBookService;

        public OrderBookController(IOrderBookService orderBookService)
        {
            _orderBookService = orderBookService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status200OK)]
        public IActionResult GetOrderedBooks()
        {
            var orderedBooks = _orderBookService.GetOrderedBooks();

            return Ok(orderedBooks);
        }
    }
}
