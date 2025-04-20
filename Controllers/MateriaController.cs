using Lab05RQuispe.Models;
using Lab05RQuispe.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab05RQuispe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MateriaController : ControllerBase
{
    private readonly IMateriaService _materiaService;

    public MateriaController(IMateriaService materiaService)
    {
        _materiaService = materiaService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var materias = await _materiaService.GetAllAsync();
        return Ok(materias);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var materia = await _materiaService.GetByIdAsync(id);
        if (materia == null)
            return NotFound();
        return Ok(materia);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] materia materia)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _materiaService.AddAsync(materia);
        return CreatedAtAction(nameof(GetById), new { id = materia.id_materia }, materia);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] materia materia)
    {
        if (id != materia.id_materia)
            return BadRequest("ID mismatch");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _materiaService.UpdateAsync(materia);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existingMateria = await _materiaService.GetByIdAsync(id);
        if (existingMateria == null)
            return NotFound();

        await _materiaService.DeleteAsync(id);
        return NoContent();
    }
}