using Lab05RQuispe.Models;
using Lab05RQuispe.UnitOfWork.IUnitOfWork;

namespace Lab05RQuispe.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IUnitOfWork _unitOfWork;

    public MatriculaService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<matricula>> GetAllAsync()
    {
        return await _unitOfWork.Repository<matricula>().GetAllAsync();
    }

    public async Task<matricula?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<matricula>().GetByIdAsync(id);
    }

    public async Task AddAsync(matricula matricula)
    {
        await _unitOfWork.Repository<matricula>().AddAsync(matricula);
        await _unitOfWork.Complete();
    }

    public async Task UpdateAsync(matricula matricula)
    {
        _unitOfWork.Repository<matricula>().Update(matricula);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var matricula = await _unitOfWork.Repository<matricula>().GetByIdAsync(id);
        if (matricula != null)
        {
            _unitOfWork.Repository<matricula>().Remove(matricula);
            await _unitOfWork.Complete();
        }
    }

    public async Task HandleMatriculaAsync(int idCurso, int idEstudiante, int idProfesor, string semestre)
    {
        await _unitOfWork.HandleMatriculaAsync(idCurso, idEstudiante, idProfesor, semestre);
    }
}