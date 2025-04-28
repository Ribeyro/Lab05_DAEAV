using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface IProfesoreService
    {
        Task<IEnumerable<Profesore>> GetAllAsync();
        Task<Profesore?> GetByIdAsync(int id);
        Task AddAsync(Profesore profesore);
        Task UpdateAsync(Profesore profesore);
        Task DeleteAsync(int id);
    }