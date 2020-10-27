using System.Collections.Generic;
using System.Linq;
using BookStoreAPI.Repositories.Interfaces;
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