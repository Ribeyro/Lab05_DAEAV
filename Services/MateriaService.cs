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

    public async Task<IEnumerable<Materia>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Materia>().GetAllAsync();
    }

    public async Task<Materia?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Materia>().GetByIdAsync(id);
    }

    public async Task AddAsync(Materia materia)
    {
        await _unitOfWork.Repository<Materia>().AddAsync(materia);
        await _unitOfWork.Complete();
    }

    public async Task UpdateAsync(Materia materia)
    {
        _unitOfWork.Repository<Materia>().Update(materia);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var materia = await _unitOfWork.Repository<Materia>().GetByIdAsync(id);
        if (materia != null)
        {
            _unitOfWork.Repository<Materia>().Remove(materia);
            await _unitOfWork.Complete();
        }
    }
}