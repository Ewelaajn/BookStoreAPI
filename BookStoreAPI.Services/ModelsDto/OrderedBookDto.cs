using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.ModelsDto
{
    public class OrderedBookDto
    {
        public string Title { get; set; }
        public AuthorDto AuthorDto { get; set; }
    }
}
