using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Api
{
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
    }
}