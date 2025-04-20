using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;

public interface IMatriculaService
{
    Task<IEnumerable<matricula>> GetAllAsync();
    Task<matricula?> GetByIdAsync(int id);
    Task AddAsync(matricula matricula);
    Task UpdateAsync(matricula matricula);
    Task DeleteAsync(int id);
    Task HandleMatriculaAsync(int idCurso, int idEstudiante, int idProfesor, string semestre);
}