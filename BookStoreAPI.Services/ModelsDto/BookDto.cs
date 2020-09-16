﻿namespace BookStoreAPI.Services.ModelsDto
{
    public class BookDto
    {
        public string Title { get; set; }
        public AuthorDto AuthorDto { get; set; }
        public decimal Price { get; set; }
    }
}