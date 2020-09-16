using System.Collections.Generic;
using BookStoreAPI.Repositories.Models;

namespace BookStoreAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Book CreateBook(Book book);
        Book GetBookByTitle(string title);
        IEnumerable<Book> GetAllBooks();
        Book UpdateBook(string currentTitle, string newTitle, int newAuthorId, decimal newPrice);
        Book DeleteBook(Book book);
    }
}