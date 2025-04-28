using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;

public interface IMatriculaService
{
    Task<IEnumerable<Matricula>> GetAllAsync();
    Task<Matricula?> GetByIdAsync(int id);
    Task AddAsync(Matricula matricula);
    Task UpdateAsync(Matricula matricula);
    Task DeleteAsync(int id);
    Task HandleMatriculaAsync(int idCurso, int idEstudiante, int idProfesor, string semestre);
}