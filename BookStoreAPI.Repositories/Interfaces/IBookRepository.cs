using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Models;

namespace BookStoreAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
       IEnumerable<Book> GetAllBooks();
       Book CreateBook(Book book);
       Book DeleteBook(Book book);
       Book GetBookByTitle(string title);

    }
}
