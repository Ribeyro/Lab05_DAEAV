using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface IEvaluacioneService
    {
        Task<IEnumerable<evaluacione>> GetAllAsync();
        Task<evaluacione?> GetByIdAsync(int id);
        Task AddAsync(evaluacione evaluacione);
        Task UpdateAsync(evaluacione evaluacione);
        Task DeleteAsync(int id);
    }