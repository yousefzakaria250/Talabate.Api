using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Talabat.BLL.Errors;

namespace Talabat.Api.Controllers
{
    [Route("errors/{code}")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)] 
    public class ErrorsController : ControllerBase
    {
        public ActionResult Error( int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
