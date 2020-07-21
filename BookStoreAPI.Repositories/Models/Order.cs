using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Repositories.Models
{
    public class Order
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
    }
}
