using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.Mappings.Interfaces;
using BookStoreAPI.Services.Models_DTO;

namespace BookStoreAPI.Services
{
    // Services map database logic to business logic
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookMapper _bookMapper;

        // Iject repository and mapper using DI
        public BookService(IBookRepository bookRepository, IBookMapper bookMapper)
        {
            _bookRepository = bookRepository;
            _bookMapper = bookMapper;
        }
        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return books.Select(book => _bookMapper.BookToDtoMapper(book));
        }
        public BookDto CreateBook(BookDto bookDto)
        {
            var bookToCreate = _bookMapper.DtoToBook(bookDto);
            var newBook = _bookRepository.CreateBook(bookToCreate);
            return _bookMapper.BookToDtoMapper(newBook);
        }
    }
}