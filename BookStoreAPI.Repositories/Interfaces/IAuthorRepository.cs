using System.Collections.Generic;
using BookStoreAPI.Repositories.Models;

public interface IAuthorRepository
{
    Author CreateAuthor(string firstName, string lastName);
    Author GetAuthor(string firstName, string lastName);
    Author GetAuthorById(int authorId);
    IEnumerable<Author> GetAuthorsByIds(List<int> ids);
    IEnumerable<Author> GetAllAuthors();

    Author UpdateAuthor(string currentFirstName, string currentLastName,
        string newFirstName, string newLastName);

    Author DeleteAuthor(string firstName, string lastName);
}