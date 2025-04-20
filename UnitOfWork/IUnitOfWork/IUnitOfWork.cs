using Lab05RQuispe.Repository.IRepository;

namespace Lab05RQuispe.UnitOfWork.IUnitOfWork;

public interface IUnitOfWork
{
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
    Task HandleMatriculaAsync(int idCurso, int idEstudiante, int idProfesor, string semestre);
}