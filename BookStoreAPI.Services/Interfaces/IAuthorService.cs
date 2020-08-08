using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Models_DTO;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDto CreateAuthor(AuthorDto authorDto);
        AuthorDto DeleteAuthor(AuthorDto authorDto);
    }
}
