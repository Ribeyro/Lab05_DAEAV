using Lab05RQuispe.Models;
    using Lab05RQuispe.UnitOfWork.IUnitOfWork;
    
    namespace Lab05RQuispe.Services;
    
    public class CursoService : ICursoService
    {
        private readonly IUnitOfWork _unitOfWork;
    
        public CursoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    
        public async Task<IEnumerable<Curso>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Curso>().GetAllAsync();
        }
    
        public async Task<Curso?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
        }
    
        public async Task AddAsync(Curso curso)
        {
            await _unitOfWork.Repository<Curso>().AddAsync(curso);
            await _unitOfWork.Complete();
        }
    
        public async Task UpdateAsync(Curso curso)
        {
            _unitOfWork.Repository<Curso>().Update(curso);
            await _unitOfWork.Complete();
        }
    
        public async Task DeleteAsync(int id)
        {
            var curso = await _unitOfWork.Repository<Curso>().GetByIdAsync(id);
            if (curso != null)
            {
                _unitOfWork.Repository<Curso>().Remove(curso);
                await _unitOfWork.Complete();
            }
        }
    }