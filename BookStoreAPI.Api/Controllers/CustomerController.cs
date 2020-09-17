using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class CustomerController : ApiControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllCustomers()
        {
            var customersDto = _customerService.GetAllCustomers();

            if (customersDto.Any()) return Ok(customersDto);

            return NoContent();
        }
    }
}