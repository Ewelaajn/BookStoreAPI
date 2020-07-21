using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Repositories.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public int PhoneNumber { get; set; }
        public string City { get; set; }
    }
}
