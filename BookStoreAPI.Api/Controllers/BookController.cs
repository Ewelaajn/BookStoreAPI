using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.Models_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.AccessControl;

namespace BookStoreAPI.Api.Controllers
{
    // Controller found under api/book
    [Produces(MediaTypeNames.Application.Json)] // Media type returned from controller
    public class BookController : ApiControllerBase
    {
        private readonly IBookService _bookService;
        // Injecting services using DI
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // Endpoint - does actuall work where called
        // Can return json response + status code
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, type: typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        public IActionResult GetAllBooks()
        {
            var booksDto = _bookService.GetAllBooks();

            if(booksDto.Any())
            {
                return Ok(booksDto);
            }

            return NoContent();
            
        }

        [HttpPost]
        [ProducesResponseType(statusCode: StatusCodes.Status201Created, type: typeof(BookDto))]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]
        public IActionResult CreateNewBook([FromBody] BookDto book)
        {
            try
            {
                var bookDto = _bookService.CreateBook(book);

                if(bookDto == null)
                {
                    return BadRequest();
                }

                return Created("/", bookDto);
            }

            catch(Exception ex)
            {
                throw;
            }
            return Ok();
        }
    }
}
