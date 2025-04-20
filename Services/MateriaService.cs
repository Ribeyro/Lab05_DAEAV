using Lab05RQuispe.Models;
using Lab05RQuispe.UnitOfWork.IUnitOfWork;

namespace Lab05RQuispe.Services;

public class MateriaService : IMateriaService
{
    private readonly IUnitOfWork _unitOfWork;

    public MateriaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<materia>> GetAllAsync()
    {
        return await _unitOfWork.Repository<materia>().GetAllAsync();
    }

    public async Task<materia?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<materia>().GetByIdAsync(id);
    }

    public async Task AddAsync(materia materia)
    {
        await _unitOfWork.Repository<materia>().AddAsync(materia);
        await _unitOfWork.Complete();
    }

    public async Task UpdateAsync(materia materia)
    {
        _unitOfWork.Repository<materia>().Update(materia);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var materia = await _unitOfWork.Repository<materia>().GetByIdAsync(id);
        if (materia != null)
        {
            _unitOfWork.Repository<materia>().Remove(materia);
            await _unitOfWork.Complete();
        }
    }
}