using Lab05RQuispe.Models;
using Lab05RQuispe.UnitOfWork.IUnitOfWork;

namespace Lab05RQuispe.Services;

public class EstudianteService : IEstudianteService
{
    private readonly IUnitOfWork _unitOfWork;

    public EstudianteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<estudiante>> GetAllAsync()
    {
        return await _unitOfWork.Repository<estudiante>().GetAllAsync();
    }

    public async Task<estudiante?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<estudiante>().GetByIdAsync(id);
    }

    public async Task AddAsync(estudiante estudiante)
    {
        await _unitOfWork.Repository<estudiante>().AddAsync(estudiante);
        await _unitOfWork.Complete();
    }

    public async Task UpdateAsync(estudiante estudiante)
    {
        _unitOfWork.Repository<estudiante>().Update(estudiante);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var estudiante = await _unitOfWork.Repository<estudiante>().GetByIdAsync(id);
        if (estudiante != null)
        {
            _unitOfWork.Repository<estudiante>().Remove(estudiante);
            await _unitOfWork.Complete();
        }
    }
}