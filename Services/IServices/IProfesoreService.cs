using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface IProfesoreService
    {
        Task<IEnumerable<profesore>> GetAllAsync();
        Task<profesore?> GetByIdAsync(int id);
        Task AddAsync(profesore profesore);
        Task UpdateAsync(profesore profesore);
        Task DeleteAsync(int id);
    }