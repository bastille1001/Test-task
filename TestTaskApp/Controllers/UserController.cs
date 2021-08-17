using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTaskApp.DataAccess;
using TestTaskApp.Services.Model;
using TestTaskApp.Services.Services.Interfaces;

namespace TestTaskApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService) =>
            this.userService = userService;

        [HttpGet("getall")]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await userService.GetAllAsync();
            if (users.Count > 0)
                return Ok(users);
            return NoContent();
        }
        
        [HttpPost("save")]
        public async Task<ActionResult> Save([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await userService.SaveAsync(user);
            return Ok("succesfully added");
        }

        [HttpGet("calculate")]
        public async Task<ActionResult<double[]>> Calculate(int xDay = 7)
        {
            double[] result = await userService.CalculateAsync(xDay);
            return Ok(result);
        }
    }
}
