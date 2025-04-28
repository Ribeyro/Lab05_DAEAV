using Lab05RQuispe.DTOs;
using Lab05RQuispe.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab05RQuispe.Controllers
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
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Authenticate(request.Username, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }

        // Endpoint accesible solo para Profesores
        [Authorize(Roles = "Profesor")]
        [HttpGet("professor-only")]
        public IActionResult ProfessorOnly()
        {
            return Ok("Solo los profesores pueden acceder a esta información.");
        }

        // Endpoint accesible solo para Estudiantes
        [Authorize(Roles = "Estudiante")]
        [HttpGet("student-only")]
        public IActionResult StudentOnly()
        {
            return Ok("Solo los estudiantes pueden acceder a esta información.");
        }
    }
}