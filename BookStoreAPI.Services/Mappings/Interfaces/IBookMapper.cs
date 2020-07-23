using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Models_DTO;

namespace BookStoreAPI.Services.Mappings.Interfaces
{
    public interface IBookMapper
    {
        BookDto BookToDtoMapper(Book book);
        Book DtoToBook(BookDto bookDto);
    }
}
