using System.Collections.Generic;
using BookStoreAPI.Repositories.Models;

namespace BookStoreAPI.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        Customer CreateCustomer(Customer customer);
        Customer GetCustomerByFullName(string firstName, string lastName);
        IEnumerable<Customer> GetAllCustomers();
    }
}