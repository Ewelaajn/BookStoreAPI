using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Services.Models_DTO;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks();

        BookDto CreateBook(BookDto bookDto);
        BookDto DeleteBook(string title);
    }
}
