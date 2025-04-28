using Lab05RQuispe.Models;
    using Lab05RQuispe.Services;
    using Microsoft.AspNetCore.Mvc;
    
    namespace Lab05RQuispe.Controllers;
    
    [ApiController]
    [Route("api/[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;
    
        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var estudiantes = await _estudianteService.GetAllAsync();
            return Ok(estudiantes);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var estudiante = await _estudianteService.GetByIdAsync(id);
            if (estudiante == null)
                return NotFound();
            return Ok(estudiante);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estudiante estudiante)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            await _estudianteService.AddAsync(estudiante);
            return CreatedAtAction(nameof(GetById), new { id = estudiante.IdEstudiante }, estudiante);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Estudiante estudiante)
        {
            if (id != estudiante.IdEstudiante)
                return BadRequest("ID mismatch");
    
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            await _estudianteService.UpdateAsync(estudiante);
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEstudiante = await _estudianteService.GetByIdAsync(id);
            if (existingEstudiante == null)
                return NotFound();
    
            await _estudianteService.DeleteAsync(id);
            return NoContent();
        }
    }