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

    public async Task<IEnumerable<Estudiante>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Estudiante>().GetAllAsync();
    }

    public async Task<Estudiante?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
    }

    public async Task AddAsync(Estudiante estudiante)
    {
        await _unitOfWork.Repository<Estudiante>().AddAsync(estudiante);
        await _unitOfWork.Complete();
    }

    public async Task UpdateAsync(Estudiante estudiante)
    {
        _unitOfWork.Repository<Estudiante>().Update(estudiante);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var estudiante = await _unitOfWork.Repository<Estudiante>().GetByIdAsync(id);
        if (estudiante != null)
        {
            _unitOfWork.Repository<Estudiante>().Remove(estudiante);
            await _unitOfWork.Complete();
        }
    }
}