using Lab05RQuispe.Models;

namespace Lab05RQuispe.Services;
    
    public interface IMateriaService
    {
        Task<IEnumerable<Materia>> GetAllAsync();
        Task<Materia?> GetByIdAsync(int id);
        Task AddAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        Task DeleteAsync(int id);
    }