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
    
        public async Task<IEnumerable<Evaluacione>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Evaluacione>().GetAllAsync();
        }
    
        public async Task<Evaluacione?> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
        }
    
        public async Task AddAsync(Evaluacione evaluacione)
        {
            await _unitOfWork.Repository<Evaluacione>().AddAsync(evaluacione);
            await _unitOfWork.Complete();
        }
    
        public async Task UpdateAsync(Evaluacione evaluacione)
        {
            _unitOfWork.Repository<Evaluacione>().Update(evaluacione);
            await _unitOfWork.Complete();
        }
    
        public async Task DeleteAsync(int id)
        {
            var evaluacione = await _unitOfWork.Repository<Evaluacione>().GetByIdAsync(id);
            if (evaluacione != null)
            {
                _unitOfWork.Repository<Evaluacione>().Remove(evaluacione);
                await _unitOfWork.Complete();
            }
        }
    }