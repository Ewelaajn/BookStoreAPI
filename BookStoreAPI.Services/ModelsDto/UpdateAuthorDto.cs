using System;
using System.Collections.Generic;
using System.Text;

namespace BookStoreAPI.Services.ModelsDto
{
    public class UpdateAuthorDto
    {
        public string CurrentFirstName { get; set; }
        public string CurrentLastName { get; set; }
        public string NewFirstName { get; set; }
        public string NewLastName { get; set; }
    }
}
