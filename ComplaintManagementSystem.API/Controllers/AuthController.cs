using ComplaintManagementSystem.Application.DTOs;
using ComplaintManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ComplaintManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult login(LoginDto dto)
        {
            var token = _authService.Login(dto);
            return Ok(new { token});
        }


    }
}
