using System;
using System.Collections.Generic;
using BookStoreAPI.Repositories.DbConnection;
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
            var customer = _db.Connection.QueryFirstOrDefault<Customer>(
                CustomerQueries.GetCustomerByFullName, new {firstName, lastName});

            return customer;
        }

        public Customer CreateCustomer(Customer customer)
        {
            var id = _db.Connection.QueryFirst<int>(CustomerQueries.CreateCustomer, new
            {
                customer.FirstName,
                customer.LastName,
                customer.Mail,
                customer.PhoneNumber,
                customer.City
            });

            var newCustomer = _db.Connection.QueryFirstOrDefault<Customer>(
                CustomerQueries.GetCustomerById, new {id});

            return newCustomer;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _db.Connection.QueryFirstOrDefault<Customer>(
                CustomerQueries.GetCustomerById, new {id});

            return customer;
        }
    }
}