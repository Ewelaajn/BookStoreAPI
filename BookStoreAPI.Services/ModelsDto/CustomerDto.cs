using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.ModelsDto
{
    public class CustomerDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
