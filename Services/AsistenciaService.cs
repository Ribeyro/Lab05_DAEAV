using Lab05RQuispe.Models;
using Lab05RQuispe.UnitOfWork.IUnitOfWork;

namespace Lab05RQuispe.Services;

public class AsistenciaService : IAsistenciaService
{
    private readonly IUnitOfWork _unitOfWork;

    public AsistenciaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Asistencia>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Asistencia>().GetAllAsync();
    }

    public async Task<Asistencia?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Asistencia>().GetByIdAsync(id);
    }

    public async Task AddAsync(Asistencia asistencia)
    {
        await _unitOfWork.Repository<Asistencia>().AddAsync(asistencia);
        await _unitOfWork.Complete();
    }

    public async Task UpdateAsync(Asistencia asistencia)
    {
        _unitOfWork.Repository<Asistencia>().Update(asistencia);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var asistencia = await _unitOfWork.Repository<Asistencia>().GetByIdAsync(id);
        if (asistencia != null)
        {
            _unitOfWork.Repository<Asistencia>().Remove(asistencia);
            await _unitOfWork.Complete();
        }
    }
}