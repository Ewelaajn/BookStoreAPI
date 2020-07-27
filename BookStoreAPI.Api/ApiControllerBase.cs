using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Api
{
    // Basic configuration for controllers
    // "Route" mapping pattern 
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
    }
}