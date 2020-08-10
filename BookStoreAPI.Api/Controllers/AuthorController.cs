using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthorController : ApiControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AuthorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllAuthors()
        {
            var authors = _authorService.GetAllAuthors();

            if (authors == null || !authors.Any())
            {
                return NoContent();
            }
            return Ok(authors); 
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateAuthor([FromBody]AuthorDto authorDto)
        {
            AuthorDto author = _authorService.CreateAuthor(authorDto);

            if(author == null)
            {
                return BadRequest("Cannot create author, Author with those credentials probably exists.");
            }
            return Created("/", author);
        }

        [HttpPut]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateAuthor([FromBody] UpdateAuthorDto updateAuthorDto)
        {
            AuthorDto updateAuthor = _authorService.UpdateAuthor(updateAuthorDto);

            if (updateAuthor == null)
            {
                return NotFound("Author with those credentials does not exist.");
            }

            return Ok(updateAuthor);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteAuthor([FromBody] AuthorDto authorDto)
        {
            AuthorDto author = _authorService.DeleteAuthor(authorDto);
            if (author == null)
            {
                return NotFound("Author with those credentials does not exist.");
            }

            return Ok(author);
        }

    }
}
