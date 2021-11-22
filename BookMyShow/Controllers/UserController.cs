using BookMyShow.Interfaces;
using BookMyShow.Models.DTOModels.InputDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // Post
        // api/User
        /// <summary>
        /// Register new user 
        /// <returns>200 created</returns>
        /// <response code="200">If everyting is fine return 200</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult RegisterUser([FromBody] RegisterUserDTO registerUserDTO)
        {
            _userService.RegisterUser(registerUserDTO);
            return Ok();
        }
    }
}
