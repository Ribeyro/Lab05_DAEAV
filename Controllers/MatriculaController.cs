using Lab05RQuispe.Models;
using Lab05RQuispe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MatriculaController : ControllerBase
{
    private readonly IMatriculaService _matriculaService;

    public MatriculaController(IMatriculaService matriculaService)
    {
        _matriculaService = matriculaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var matriculas = await _matriculaService.GetAllAsync();
        return Ok(matriculas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var matricula = await _matriculaService.GetByIdAsync(id);
        if (matricula == null)
            return NotFound();
        return Ok(matricula);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Matricula matricula)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _matriculaService.AddAsync(matricula);
        return CreatedAtAction(nameof(GetById), new { id = matricula.IdMatricula }, matricula);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Matricula matricula)
    {
        if (id != matricula.IdMatricula)
            return BadRequest("ID mismatch");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _matriculaService.UpdateAsync(matricula);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingMatricula = await _matriculaService.GetByIdAsync(id);
        if (existingMatricula == null)
            return NotFound();

        await _matriculaService.DeleteAsync(id);
        return NoContent();
    }
}