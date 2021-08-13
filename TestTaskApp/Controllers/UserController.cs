﻿using Microsoft.AspNetCore.Http;
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

        [HttpPost("save")]
        public async Task<ActionResult> Save([FromBody] UserDto user)
        {
            await userService.SaveAsync(user);
            return Ok("succesfully added");
        }

        [HttpGet("calculate")]
        public async Task<ActionResult<double>> Calculate(int xDay)
        {
            double result = await userService.CalculateAsync(xDay);
            return Ok(result);
        }
    }
}
