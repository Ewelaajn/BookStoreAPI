namespace BookStoreAPI.Repositories.Queries
{
    public class AuthorQueries
    {
        public const string CreateAuthor = @"
                INSERT INTO shop.author(first_name, last_name)
                VALUES (@first_name, @last_name) RETURNING id";

        public const string GetAuthor = @"
                SELECT id AS Id,
                       first_name AS FirstName,
                       last_name AS LastName
                FROM   shop.author
                WHERE  first_name = @first_name AND last_name = @last_name";

        public const string GetAuthorById = @"
                SELECT id AS Id,
                       first_name AS firstName,
                       last_name AS lastName
                FROM   shop.author
                WHERE id = @id";

        public const string GetAuthorsByIds = @"
                SELECT id AS Id,
                       first_name AS FirstName,
                       last_name AS LastName
                FROM   shop.author
                WHERE  id = ANY(@ids)";

        public const string GetAllAuthors = @"
                SELECT id AS Id,
                       first_name AS FirstName,
                       last_name AS LastName
                FROM   shop.author";

        public const string UpdateAuthor = @"
                UPDATE shop.author
                SET 
                    first_name = @newFirstName,
                    last_name = @newLastName
                WHERE 
                    first_name = @currentFirstName 
                AND last_name = @currentLastName
                RETURNING 
                         first_name AS FirstName,
                         last_name AS LastName";

        public const string DeleteAuthor = @"
                DELETE FROM shop.author
                WHERE first_name = @first_name 
                AND last_name = @last_name
                RETURNING 
                         id AS Id,
                         first_name AS FirstName,
                         last_name AS LastName";
    }
}