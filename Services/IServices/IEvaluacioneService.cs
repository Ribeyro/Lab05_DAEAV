using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface IEvaluacioneService
    {
        Task<IEnumerable<Evaluacione>> GetAllAsync();
        Task<Evaluacione?> GetByIdAsync(int id);
        Task AddAsync(Evaluacione evaluacione);
        Task UpdateAsync(Evaluacione evaluacione);
        Task DeleteAsync(int id);
    }