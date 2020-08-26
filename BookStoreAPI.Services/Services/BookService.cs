using System;
using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.Mappings.Interfaces;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBookMapper _bookMapper;
        private readonly IAuthorRepository _authorRepository;
        public BookService(IBookRepository bookRepository, IBookMapper bookMapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _bookMapper = bookMapper;
            _authorRepository = authorRepository;
            
        }
        public BookDto CreateBook(BookDto bookDto)
        {
            AuthorDto authorDto = bookDto.AuthorDto;
            Author author = _authorRepository.GetAuthor(authorDto.FirstName, authorDto.LastName);

            if (author == null)
            {
                return null;
            }

            Book bookToCreate = _bookMapper.DtoToBook(bookDto, author.Id);
            Book newBook = _bookRepository.CreateBook(bookToCreate);

            return _bookMapper.BookToDto(newBook, author);
        }

        public IEnumerable<BookDto> GetAllBooks()
        {
            var books = _bookRepository.GetAllBooks().ToList();
            var authorsIds = books.Select(book => book.AuthorId).ToList();
            var authors = _authorRepository.GetAuthorsByIds(authorsIds).ToList();
            return _bookMapper.BooksToDtos(books, authors);
        }

        public BookDto UpdateBook(UpdateBookDto updateBookDto)
        {
            var author = _authorRepository.GetAuthor
                (updateBookDto.NewAuthorDto.FirstName, updateBookDto.NewAuthorDto.LastName);

            var book = _bookRepository.GetBookByTitle(updateBookDto.CurrentTitle);

            if (book == null || author == null)
            {
                return null;
            }

            var updatedBook = _bookRepository.UpdateBook
                (updateBookDto.CurrentTitle, updateBookDto.NewTitle, author.Id, updateBookDto.NewPrice);

            return _bookMapper.BookToDto(updatedBook, author);
        }

        public BookDto DeleteBook(string title)
        {
            Book bookByTitleToDelete = _bookRepository.GetBookByTitle(title);

            if (bookByTitleToDelete == null)
            {
                return null;
            }

            Author author = _authorRepository.GetAuthorById(bookByTitleToDelete.AuthorId);
            Book deletedBook = _bookRepository.DeleteBook(bookByTitleToDelete);

            return _bookMapper.BookToDto(deletedBook, author);
        }
    }
}