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
    }
}