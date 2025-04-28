using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> GetAllAsync();
        Task<Curso?> GetByIdAsync(int id);
        Task AddAsync(Curso curso);
        Task UpdateAsync(Curso curso);
        Task DeleteAsync(int id);
    }