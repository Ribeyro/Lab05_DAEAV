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

    public async Task<IEnumerable<Matricula>> GetAllAsync()
    {
        return await _unitOfWork.Repository<Matricula>().GetAllAsync();
    }

    public async Task<Matricula?> GetByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
    }

    public async Task AddAsync(Matricula matricula)
    {
        await _unitOfWork.Repository<Matricula>().AddAsync(matricula);
        await _unitOfWork.Complete();
    }

    public async Task UpdateAsync(Matricula matricula)
    {
        _unitOfWork.Repository<Matricula>().Update(matricula);
        await _unitOfWork.Complete();
    }

    public async Task DeleteAsync(int id)
    {
        var matricula = await _unitOfWork.Repository<Matricula>().GetByIdAsync(id);
        if (matricula != null)
        {
            _unitOfWork.Repository<Matricula>().Remove(matricula);
            await _unitOfWork.Complete();
        }
    }

    public async Task HandleMatriculaAsync(int idCurso, int idEstudiante, int idProfesor, string semestre)
    {
        await _unitOfWork.HandleMatriculaAsync(idCurso, idEstudiante, idProfesor, semestre);
    }
}