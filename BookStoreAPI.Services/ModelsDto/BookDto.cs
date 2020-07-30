using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.Models_DTO
{
    public class BookDto
    {
        public string Title { get; set; }
        public AuthorDto Author { get; set; }
        public decimal Price { get; set; }
    }
}
