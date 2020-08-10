using System;
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
    public class BookController : ApiControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllBooks()
        {
            var booksDto = _bookService.GetAllBooks();

            if (booksDto.Any()) return Ok(booksDto);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public IActionResult CreateNewBook([FromBody] BookDto book)
        {
            try
            {
                var bookDto = _bookService.CreateBook(book);

                if (bookDto == null) return BadRequest("Author with those credentials does not exists!");

                return Created("/", bookDto);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BookDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(string title)
        {
            var deletedBook = _bookService.DeleteBook(title);
            if (deletedBook == null) return NotFound("Book does not exist");

            return Ok(deletedBook);
        }
    }
}