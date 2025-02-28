﻿using HRMS.Application.Models.UserDTOModels;
using HRMS.Application.Services.UsereService;
using HRMS.Domain.Data.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.API.Controllers
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

        [HttpPost("Register"), Authorize(Roles = "HumanResource")]
        public async Task<IActionResult> Register([FromBody]RegisterDTO registerDTO)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var response = await _userService.RegisterAsync(registerDTO);
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            AuthenticationDTO response = null;
            try
            {
                response = await _userService.LoginAsync(loginDTO);
                return Ok(response);
            }catch
            {
                
            }

            return BadRequest(response);
        }

        [HttpGet, Authorize(Roles = "HumanResource")]
        public string test()
        {
            return "secured text";
        }
    }
}
