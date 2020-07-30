using System.Collections.Generic;
using BookStoreAPI.Repositories.Models;

public interface IAuthorRepository
{
    Author GetAuthor(string firstName, string lastName);
    Author CreateAuthor(string firstName, string lastName);
    Author GetAuthorById(int authorId);
    IEnumerable<Author> GetAuthorsByIds(List<int> ids);
    IEnumerable<Author> GetAllAuthors();
}