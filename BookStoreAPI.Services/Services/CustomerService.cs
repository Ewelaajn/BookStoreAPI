using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Repositories.Interfaces;
using BookStoreAPI.Repositories.Models;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public CustomerDto CreateCustomer(CustomerDto customer)
        {
            var cust = _customerRepository.GetCustomerByFullName(customer.FirstName, customer.LastName);

            if (cust != null)
                return null;

            var custToCreate = new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Mail = customer.Mail,
                PhoneNumber = customer.PhoneNumber,
                City = customer.City
            };

            var newCustomer = _customerRepository.CreateCustomer(custToCreate);

            return new CustomerDto
            {
                FirstName = newCustomer.FirstName,
                LastName = newCustomer.LastName,
                Mail = newCustomer.Mail,
                PhoneNumber = newCustomer.PhoneNumber,
                City = newCustomer.City
            };
        }

        public IEnumerable<CustomerDto> GetAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers().ToList();

            return customers.Select(customer => new CustomerDto
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Mail = customer.Mail,
                PhoneNumber = customer.PhoneNumber,
                City = customer.City
            });
        }
    }
}