using System.Collections.Concurrent;
using Lab05RQuispe.Models;
using Lab05RQuispe.Repository;
using Lab05RQuispe.Repository.IRepository;

namespace Lab05RQuispe.UnitOfWork;

public class UnitOfWork : IUnitOfWork.IUnitOfWork
{
    private readonly Lab05Context _context;
    private readonly ConcurrentDictionary<string, object> _repositories;

    public UnitOfWork(Lab05Context context)
    {
        _context = context;
        _repositories = new ConcurrentDictionary<string, object>();
    }

    public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var typeName = typeof(TEntity).Name;

        if (_repositories.ContainsKey(typeName))
            return (IGenericRepository<TEntity>)_repositories[typeName];

        var repositoryInstance = new GenericRepository<TEntity>(_context);
        _repositories.TryAdd(typeName, repositoryInstance);

        return repositoryInstance;
    }

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task HandleMatriculaAsync(int idCurso, int idEstudiante, int idProfesor, string semestre)
    {
        var curso = await _context.cursos.FindAsync(idCurso);
        if (curso == null)
            throw new Exception("Curso not found");

        var estudiante = await _context.estudiantes.FindAsync(idEstudiante);
        if (estudiante == null)
            throw new Exception("Estudiante not found");

        var profesor = await _context.profesores.FindAsync(idProfesor);
        if (profesor == null)
            throw new Exception("Profesor not found");

        var matricula = new matricula
        {
            id_curso = idCurso,
            id_estudiante = idEstudiante,
            semestre = semestre
        };

        await _context.matriculas.AddAsync(matricula);
        await Complete();
    }
}