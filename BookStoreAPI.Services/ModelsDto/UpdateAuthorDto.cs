using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.ModelsDto
{
    public class UpdateAuthorDto
    {
        public AuthorDto AuthorDto { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
    }
}
