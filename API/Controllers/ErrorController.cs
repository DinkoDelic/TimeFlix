using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("errors/{code}")]
    // We ignore this controller to avoid swagger error
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        // Client gets redirected to this controller after they make a request to invalid endpoint
        public IActionResult Error(int code)
        {
            // Uses our ApiResponse class to generate a consistent error message
            return new ObjectResult(new ApiResponse(code));
        }
    }
}