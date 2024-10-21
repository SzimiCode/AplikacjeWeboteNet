using Microsoft.AspNetCore.Mvc;

namespace Cars.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //endpoint zawsze zaczyna się "api/...
    public class BaseApiController : ControllerBase
    {
    }
}
