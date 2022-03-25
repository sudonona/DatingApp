using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //strat with api /controller

    public class BaseApiController : ControllerBase
    {
        public class UsersController : BaseApiController
        {
        }
    }
}
