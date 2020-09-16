namespace BookStoreAPI.Services.ModelsDto
{
    public class UpdateBookDto
    {
        public string CurrentTitle { get; set; }
        public string NewTitle { get; set; }
        public AuthorDto NewAuthorDto { get; set; }
        public decimal NewPrice { get; set; }
    }
}