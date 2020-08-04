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
    [Produces(MediaTypeNames.Application.Json)]
    public class BookController : ApiControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        public IActionResult GetAllBooks()
        {
            IEnumerable<BookDto> booksDto = _bookService.GetAllBooks();

            if(booksDto.Any())
            {
                return Ok(booksDto);
            }

            return NoContent();
            
        }
        [HttpPost]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        [ProducesResponseType(statusCode: StatusCodes.Status409Conflict)]
        public IActionResult CreateNewBook([FromBody] BookDto book)
        {
            try
            {
                var bookDto = _bookService.CreateBook(book);

                if(bookDto == null)
                {
                    return BadRequest("AuthorDto with those credentials does not exists!");
                }

                return Created("/", bookDto);
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        public IActionResult DeleteBook([FromBody] BookDto book)
        {
            var deletedBook = _bookService.DeleteBook(book.Title);

            return Ok(deletedBook);
        }
    }
}
