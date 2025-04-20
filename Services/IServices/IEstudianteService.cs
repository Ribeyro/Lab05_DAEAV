using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface IEstudianteService
    {
        Task<IEnumerable<estudiante>> GetAllAsync();
        Task<estudiante?> GetByIdAsync(int id);
        Task AddAsync(estudiante estudiante);
        Task UpdateAsync(estudiante estudiante);
        Task DeleteAsync(int id);
    }