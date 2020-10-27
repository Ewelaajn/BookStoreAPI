using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();

        BookDto CreateBook(BookDto bookDto);
        BookDto UpdateBook(UpdateBookDto updateBookDto);
        BookDto DeleteBook(string title);
    }
}
