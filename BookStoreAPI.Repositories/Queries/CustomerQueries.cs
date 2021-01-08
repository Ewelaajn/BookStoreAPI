namespace BookStoreAPI.Repositories.Queries
{
    public static class CustomerQueries
    {
        public const string GetAllCustomers = @"SELECT 
                                                    id AS Id,
                                                    first_name AS FirstName,
                                                    last_name AS LastName,
                                                    mail AS Mail,
                                                    phone_number AS PhoneNumber,
                                                    city AS City
                                                FROM shop.customer";

        public const string GetCustomerByMail = @"SELECT 
                                                    id AS Id,
                                                    first_name AS FirstName,
                                                    last_name AS LastName,
                                                    mail AS Mail,
                                                    phone_number AS PhoneNumber,
                                                    city AS City
                                                FROM shop.customer
                                                WHERE mail = @mail";

        public const string GetCustomerById = @"SELECT 
                                                    id AS Id,
                                                    first_name AS FirstName,
                                                    last_name AS LastName,
                                                    mail AS Mail,
                                                    phone_number AS PhoneNumber,
                                                    city AS City
                                                FROM shop.customer
                                                WHERE id = @id";

        public const string GetCustomerByFullName = @"SELECT 
                                                    id AS Id,
                                                    first_name AS FirstName,
                                                    last_name AS LastName,
                                                    mail AS Mail,
                                                    phone_number AS PhoneNumber,
                                                    city AS City
                                                FROM shop.customer
                                                WHERE first_name = @firstName AND last_name = @lastName";

        public const string CreateCustomer = @"
                INSERT INTO shop.customer(first_name, last_name, mail, phone_number, city)
                VALUES (@FirstName, @LastName, @Mail, @PhoneNumber, @City) RETURNING id";
    }
}