using System;
using HumanForce.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanForce.Api.Controllers.UsersController
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController(IUserService userService)
        {
            UserService = userService;
        }

        protected IUserService UserService { get; }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            return Ok(UserService.GetUsers());
        }
    }
}
