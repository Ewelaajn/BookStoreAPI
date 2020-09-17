using System;
using System.Collections.Generic;
using System.Text;
using BookStoreAPI.Repositories.Db;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Repositories.Queries;
using Dapper;

namespace BookStoreAPI.Repositories.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDb _db;

        public CustomerRepository(IDb db)
        {
            _db = db;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var resultConnectionCustomer = _db.Connection.Query<Customer>
                (CustomerQueries.GetAllCustomers);
            
            return resultConnectionCustomer;
        }

        public Customer GetCustomerByFullName(string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public Customer CreateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
