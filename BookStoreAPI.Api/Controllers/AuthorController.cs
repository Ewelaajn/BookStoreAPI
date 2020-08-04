using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using BookStoreAPI.Services.Interfaces;
using BookStoreAPI.Services.Models_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Api.Controllers
{
    [Produces(MediaTypeNames.Application.Json)]
    public class AuthorController : ApiControllerBase
    {
        private IAuthorService _authorService;
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
            return Ok(); 
        }

        [HttpPost]
        [ProducesResponseType(typeof(AuthorDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateAuthor([FromBody]AuthorDto authorDto)
        {
            var author = _authorService.CreateAuthor(authorDto);

            if(author == null)
            {
                return BadRequest("Cannot create author, AuthorDto with those credentials probably exists.");
            }
            return Created("/", author);
        }
    }
}
