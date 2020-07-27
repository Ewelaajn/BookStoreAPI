using BookStoreAPI.Repositories.Models;

public interface IAuthorRepository
{
    Author GetAuthor(string firstName, string lastName);
    Author CreateAuthor(string firstName, string lastName);
}