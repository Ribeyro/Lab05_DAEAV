using Lab05RQuispe.Models;
using Lab05RQuispe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfesoreController : ControllerBase
{
    private readonly IProfesoreService _profesoreService;

    public ProfesoreController(IProfesoreService profesoreService)
    {
        _profesoreService = profesoreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var profesores = await _profesoreService.GetAllAsync();
        return Ok(profesores);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var profesore = await _profesoreService.GetByIdAsync(id);
        if (profesore == null)
            return NotFound();
        return Ok(profesore);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Profesore profesore)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _profesoreService.AddAsync(profesore);
        return CreatedAtAction(nameof(GetById), new { id = profesore.IdProfesor }, profesore);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Profesore profesore)
    {
        if (id != profesore.IdProfesor)
            return BadRequest("ID mismatch");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _profesoreService.UpdateAsync(profesore);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingProfesore = await _profesoreService.GetByIdAsync(id);
        if (existingProfesore == null)
            return NotFound();

        await _profesoreService.DeleteAsync(id);
        return NoContent();
    }
}