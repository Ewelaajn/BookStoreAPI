using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Mappings.Interfaces;
using BookStoreAPI.Services.Models_DTO;


namespace BookStoreAPI.Services.Mappings
{
    public class BookMapper : IBookMapper
    {
        public IEnumerable<BookDto> BooksToDtos(IEnumerable<Book> books, IEnumerable<Author> authors)
        {
            return books.Select(book =>
            {
            Author bookAuthor = authors.First(author => author.Id == book.AuthorId);
            return BookToDto(book, bookAuthor);
            });  
            
        }

        public BookDto BookToDto(Book book, Author author)
        {
            return new BookDto
            {
                Title = book.Title,
                AuthorDto = new AuthorDto
                {
                    FirstName = author.FirstName,
                    LastName = author.LastName
                },
                Price = book.Price
            };
        }

        public Book DtoToBook(BookDto bookDto, int authorId)
        {
            return new Book
            {
                Title = bookDto.Title,
                AuthorId = authorId,
                Price = bookDto.Price
            };
        }


    }


}
