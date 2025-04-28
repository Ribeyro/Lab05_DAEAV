using Lab05RQuispe.Models;
    using Lab05RQuispe.Services;
    using Microsoft.AspNetCore.Mvc;
    
    namespace Lab05RQuispe.Controllers;
    
    [ApiController]
    [Route("api/[controller]")]
    public class EvaluacioneController : ControllerBase
    {
        private readonly IEvaluacioneService _evaluacioneService;
    
        public EvaluacioneController(IEvaluacioneService evaluacioneService)
        {
            _evaluacioneService = evaluacioneService;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var evaluaciones = await _evaluacioneService.GetAllAsync();
            return Ok(evaluaciones);
        }
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var evaluacione = await _evaluacioneService.GetByIdAsync(id);
            if (evaluacione == null)
                return NotFound();
            return Ok(evaluacione);
        }
    
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Evaluacione evaluacione)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            await _evaluacioneService.AddAsync(evaluacione);
            return CreatedAtAction(nameof(GetById), new { id = evaluacione.IdEvaluacion }, evaluacione);
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Evaluacione evaluacione)
        {
            if (id != evaluacione.IdEvaluacion)
                return BadRequest("ID mismatch");
    
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
    
            await _evaluacioneService.UpdateAsync(evaluacione);
            return NoContent();
        }
    
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingEvaluacione = await _evaluacioneService.GetByIdAsync(id);
            if (existingEvaluacione == null)
                return NotFound();
    
            await _evaluacioneService.DeleteAsync(id);
            return NoContent();
        }
    }