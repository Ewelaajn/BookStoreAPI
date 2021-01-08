using System.Collections.Generic;
using BookStoreAPI.Services.ModelsDto;

namespace BookStoreAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomers();
        CustomerDto CreateCustomer(CustomerDto customer);
    }
}