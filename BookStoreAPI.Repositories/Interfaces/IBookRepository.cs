using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Models;

namespace BookStoreAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Book CreateBook(Book book);
        Book GetBookByTitle(string title);
        IEnumerable<Book> GetAllBooks();
        Book DeleteBook(Book book);
    }
}
