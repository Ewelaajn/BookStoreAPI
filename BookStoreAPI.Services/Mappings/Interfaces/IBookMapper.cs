using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Models_DTO;

namespace BookStoreAPI.Services.Mappings.Interfaces
{
    public interface IBookMapper
    {
        BookDto BookToDto(Book book, Author author);
        Book DtoToBook(BookDto bookDto, int authorId);
        IEnumerable<BookDto> BooksToDtos(IEnumerable<Book> books, IEnumerable<Author> authors);
    }
}
