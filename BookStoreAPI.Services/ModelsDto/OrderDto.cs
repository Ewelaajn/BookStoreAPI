using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.ModelsDto
{
    public class OrderDto
    {
        public bool IsActive { get; set; }
        public DateTime OrderTime { get; set; }
        public int CustomerId { get; set; }
    }
}
