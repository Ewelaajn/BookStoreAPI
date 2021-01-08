using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public AuthorDto CreateAuthor(AuthorDto authorDto)
        {
            var author = _authorRepository.GetAuthor(authorDto.FirstName, authorDto.LastName);

            if (author != null) return null;

            var newAuthor = _authorRepository.CreateAuthor(authorDto.FirstName, authorDto.LastName);

            return new AuthorDto {FirstName = newAuthor.FirstName, LastName = newAuthor.LastName};
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

        public AuthorDto UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var updateAuthor = _authorRepository.UpdateAuthor
            (updateAuthorDto.AuthorDto.FirstName, updateAuthorDto.AuthorDto.LastName,
                updateAuthorDto.NewFirstName, updateAuthorDto.NewLastName);

            if (updateAuthor == null) return null;

            return new AuthorDto {FirstName = updateAuthor.FirstName, LastName = updateAuthor.LastName};
        }

        public AuthorDto DeleteAuthor(AuthorDto authorDto)
        {
            var author = _authorRepository.GetAuthor(authorDto.FirstName, authorDto.LastName);
            if (author == null) return null;

            var deletedAuthor = _authorRepository.DeleteAuthor(author.FirstName, author.LastName);

            return new AuthorDto {FirstName = deletedAuthor.FirstName, LastName = deletedAuthor.LastName};
        }
    }
}