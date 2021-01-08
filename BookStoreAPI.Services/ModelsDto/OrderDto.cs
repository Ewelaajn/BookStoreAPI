using System;

namespace BookStoreAPI.Services.ModelsDto
{
    public class OrderDto
    {
        public bool IsActive { get; set; }
        public DateTime OrderTime { get; set; }
        public OrderedBookDto Book { get; set; }
        public string Mail { get; set; }
    }
}