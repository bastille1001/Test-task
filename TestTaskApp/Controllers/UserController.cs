using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            var users = await userService.GetAllAsync();
            if (users.Count > 0)
                return Ok(users);
            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult> Save([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await userService.SaveAsync(user);
            return Ok(user);
        }

        [HttpGet("calculate")]
        public async Task<ActionResult<List<double>>> Calculate(int xDay = 7)
        {
            var result = await userService.CalculateAsync(xDay);
            return Ok(result);
        }
    }
}
