

using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [Route("errors/{code}")]
    public class ErrorController: BaseController
    {
        [HttpGet]
         public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }

    }
}