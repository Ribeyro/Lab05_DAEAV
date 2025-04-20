using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;

public interface IAsistenciaService
{
    Task<IEnumerable<Asistencia>> GetAllAsync();
    Task<Asistencia?> GetByIdAsync(int id);
    Task AddAsync(Asistencia asistencia);
    Task UpdateAsync(Asistencia asistencia);
    Task DeleteAsync(int id);
}