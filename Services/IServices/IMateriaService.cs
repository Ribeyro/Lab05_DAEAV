using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface IMateriaService
    {
        Task<IEnumerable<materia>> GetAllAsync();
        Task<materia?> GetByIdAsync(int id);
        Task AddAsync(materia materia);
        Task UpdateAsync(materia materia);
        Task DeleteAsync(int id);
    }