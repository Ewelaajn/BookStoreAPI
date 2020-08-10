using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthors();
        AuthorDto CreateAuthor(AuthorDto authorDto);
        AuthorDto UpdateAuthor(UpdateAuthorDto updateAuthorDto);
        AuthorDto DeleteAuthor(AuthorDto authorDto);
    }
}
