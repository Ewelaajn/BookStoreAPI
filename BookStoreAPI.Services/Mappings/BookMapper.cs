using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Mappings.Interfaces;
using BookStoreAPI.Services.Models_DTO;


namespace BookStoreAPI.Services.Mappings
{
    public class BookMapper : IBookMapper
    {
        public BookDto BookToDtoMapper(Book book)
        {
            return new BookDto
            {
                Title = book.Title,
                Author = new AuthorDto(),
                Price = book.Price
            };
        }

        public Book DtoToBook(BookDto bookDto)
        {
            return new Book
            {
                Title = bookDto.Title,
                AuthorId = 1,
                Price = bookDto.Price
            };
        }
    }


}
