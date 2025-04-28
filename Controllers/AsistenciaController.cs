using Lab05RQuispe.Models;
using Lab05RQuispe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AsistenciaController : ControllerBase
{
    private readonly IAsistenciaService _asistenciaService;

    public AsistenciaController(IAsistenciaService asistenciaService)
    {
        _asistenciaService = asistenciaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var asistencias = await _asistenciaService.GetAllAsync();
        return Ok(asistencias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var asistencia = await _asistenciaService.GetByIdAsync(id);
        if (asistencia == null)
            return NotFound();
        return Ok(asistencia);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Asistencia asistencia)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _asistenciaService.AddAsync(asistencia);
        return CreatedAtAction(nameof(GetById), new { id = asistencia.IdAsistencia }, asistencia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Asistencia asistencia)
    {
        if (id != asistencia.IdAsistencia)
            return BadRequest("ID mismatch");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _asistenciaService.UpdateAsync(asistencia);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingAsistencia = await _asistenciaService.GetByIdAsync(id);
        if (existingAsistencia == null)
            return NotFound();

        await _asistenciaService.DeleteAsync(id);
        return NoContent();
    }
}