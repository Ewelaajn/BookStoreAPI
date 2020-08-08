using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.Models_DTO;

namespace BookStoreAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public AuthorDto CreateAuthor(AuthorDto authorDto)
        {
            Author author = _authorRepository.GetAuthor(authorDto.FirstName, authorDto.LastName);
            if(author != null)
            {
                return null;
            }

            Author newAuthor = _authorRepository.CreateAuthor(authorDto.FirstName, authorDto.LastName);

            return new AuthorDto { FirstName = newAuthor.FirstName, LastName = newAuthor.LastName };
        }

        public AuthorDto DeleteAuthor(AuthorDto authorDto)
        {
            Author author = _authorRepository.GetAuthor(authorDto.FirstName, authorDto.LastName);
            if (author == null)
            {
                return null;
            }

            var deletedAuthor = _authorRepository.DeleteAuthor(author.FirstName, author.LastName);

            return new AuthorDto {FirstName = deletedAuthor.FirstName, LastName = deletedAuthor.LastName};
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            var authors = _authorRepository.GetAllAuthors();
            return authors.Select(author => new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName
            });
        }
    }
}
