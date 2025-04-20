using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface ICursoService
    {
        Task<IEnumerable<curso>> GetAllAsync();
        Task<curso?> GetByIdAsync(int id);
        Task AddAsync(curso curso);
        Task UpdateAsync(curso curso);
        Task DeleteAsync(int id);
    }