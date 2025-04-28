using Lab05RQuispe.DTOs;
using Lab05RQuispe.Models;
using Lab05RQuispe.UnitOfWork.IUnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab05RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly List<string> _allowedRoles = new List<string> { "Profesor", "Estudiante" };

    public RegisterController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        // Validar que el rol sea permitido
        if (!_allowedRoles.Contains(request.Rol))
        {
            return BadRequest(new { message = "Rol inválido. Solo se permiten los roles 'Profesor' o 'Estudiante'." });
        }

        // Verificar si ya existe un usuario con ese username
        var existingUser = (await _unitOfWork.Repository<Usuario>().FindAsync(u => u.Username == request.Username)).FirstOrDefault();
        if (existingUser != null)
        {
            return BadRequest(new { message = "El username ya está registrado." });
        }

        var user = new Usuario
        {
            Username = request.Username,
            Rol = request.Rol
        };

        var passwordHasher = new PasswordHasher<Usuario>();
        user.Password = passwordHasher.HashPassword(user, request.Password);

        await _unitOfWork.Repository<Usuario>().AddAsync(user);
        await _unitOfWork.Complete();

        return Ok(new { message = "Usuario registrado exitosamente." });
    }
}