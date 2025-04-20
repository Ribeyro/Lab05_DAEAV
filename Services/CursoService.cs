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
    
        public async Task<IEnumerable<curso>> GetAllAsync()
        {
            return await _unitOfWork.Repository<curso>().GetAllAsync();
        }
    
        public async Task<curso?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<curso>().GetByIdAsync(id);
        }
    
        public async Task AddAsync(curso curso)
        {
            await _unitOfWork.Repository<curso>().AddAsync(curso);
            await _unitOfWork.Complete();
        }
    
        public async Task UpdateAsync(curso curso)
        {
            _unitOfWork.Repository<curso>().Update(curso);
            await _unitOfWork.Complete();
        }
    
        public async Task DeleteAsync(int id)
        {
            var curso = await _unitOfWork.Repository<curso>().GetByIdAsync(id);
            if (curso != null)
            {
                _unitOfWork.Repository<curso>().Remove(curso);
                await _unitOfWork.Complete();
            }
        }
    }