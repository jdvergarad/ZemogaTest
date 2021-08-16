using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;
using ZemogaTest.Services.Services;


namespace ZemogaTest.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<ApiResponse> Login([FromBody] LoginRequest loginRequest)
        {
            var result = _userService.Login(loginRequest);

            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        // POST api/<UserController>
        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<ApiResponse>> CreateUser([FromBody] AddNewUserRequest request)
        {
            var result = await _userService.CreateUser(request);

            if (result is ErrorResponse)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
