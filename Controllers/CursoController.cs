using Lab05RQuispe.Models;
    using Lab05RQuispe.Services;
    using Microsoft.AspNetCore.Mvc;
    
    namespace Lab05RQuispe.Controllers;
    
    [ApiController]
    [Route("api/[controller]")]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _cursoService;
    
        public CursoController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cursos = await _cursoService.GetAllAsync();
            return Ok(cursos);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curso = await _cursoService.GetByIdAsync(id);
            if (curso == null)
                return NotFound();
            return Ok(curso);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] curso curso)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            await _cursoService.AddAsync(curso);
            return CreatedAtAction(nameof(GetById), new { id = curso.id_curso }, curso);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] curso curso)
        {
            if (id != curso.id_curso)
                return BadRequest("ID mismatch");
    
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            await _cursoService.UpdateAsync(curso);
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingCurso = await _cursoService.GetByIdAsync(id);
            if (existingCurso == null)
                return NotFound();
    
            await _cursoService.DeleteAsync(id);
            return NoContent();
        }
    }