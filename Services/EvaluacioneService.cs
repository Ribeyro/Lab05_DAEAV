using Lab05RQuispe.Models;
    using Lab05RQuispe.UnitOfWork.IUnitOfWork;
    
    namespace Lab05RQuispe.Services;
    
    public class EvaluacioneService : IEvaluacioneService
    {
        private readonly IUnitOfWork _unitOfWork;
    
        public EvaluacioneService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    
        public async Task<IEnumerable<evaluacione>> GetAllAsync()
        {
            return await _unitOfWork.Repository<evaluacione>().GetAllAsync();
        }
    
        public async Task<evaluacione?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<evaluacione>().GetByIdAsync(id);
        }
    
        public async Task AddAsync(evaluacione evaluacione)
        {
            await _unitOfWork.Repository<evaluacione>().AddAsync(evaluacione);
            await _unitOfWork.Complete();
        }
    
        public async Task UpdateAsync(evaluacione evaluacione)
        {
            _unitOfWork.Repository<evaluacione>().Update(evaluacione);
            await _unitOfWork.Complete();
        }
    
        public async Task DeleteAsync(int id)
        {
            var evaluacione = await _unitOfWork.Repository<evaluacione>().GetByIdAsync(id);
            if (evaluacione != null)
            {
                _unitOfWork.Repository<evaluacione>().Remove(evaluacione);
                await _unitOfWork.Complete();
            }
        }
    }