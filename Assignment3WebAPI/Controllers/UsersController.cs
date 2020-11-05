using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Data;
using Assignment3WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3WebAPI.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// Gets Users
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<User>> GetUsers([FromQuery] string userName)
        {
            try
            {
                User user = await userService.GetUserAsync(userName);
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
