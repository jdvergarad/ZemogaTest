using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZemogaTest.Services.Dtos;
using ZemogaTest.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
