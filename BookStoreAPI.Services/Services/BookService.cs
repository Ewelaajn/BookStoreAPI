using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.Mappings.Interfaces;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Services
{
    public class BookService : IBookService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookMapper _bookMapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IBookMapper bookMapper, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _bookMapper = bookMapper;
            _authorRepository = authorRepository;
        }

        public BookDto CreateBook(BookDto bookDto)
        {
            var authorDto = bookDto.AuthorDto;
            var author = _authorRepository.GetAuthor(authorDto.FirstName, authorDto.LastName);

            if (author == null) return null;

            var bookToCreate = _bookMapper.DtoToBook(bookDto, author.Id);
            var newBook = _bookRepository.CreateBook(bookToCreate);

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

            if (book == null || author == null) return null;

            var updatedBook = _bookRepository.UpdateBook
                (updateBookDto.CurrentTitle, updateBookDto.NewTitle, author.Id, updateBookDto.NewPrice);

            return _bookMapper.BookToDto(updatedBook, author);
        }

        public BookDto DeleteBook(string title)
        {
            var bookByTitleToDelete = _bookRepository.GetBookByTitle(title);

            if (bookByTitleToDelete == null) return null;

            var author = _authorRepository.GetAuthorById(bookByTitleToDelete.AuthorId);
            var deletedBook = _bookRepository.DeleteBook(bookByTitleToDelete);

            return _bookMapper.BookToDto(deletedBook, author);
        }
    }
}