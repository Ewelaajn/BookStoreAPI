using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Repositories.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;


namespace BookStoreAPI.Api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class BookController : ApiControllerBase
    {
        private readonly BookRepository _bookRepository;
        public BookController()
        {
            _bookRepository = new BookRepository();
        }
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return Json(books);
        }
        [HttpPost]
        public IActionResult CreateNewBook([FromBody] Book book)
        {
            var newBook = _bookRepository.CreateBook(book);
            return Json(newBook);
        }
    }
}
