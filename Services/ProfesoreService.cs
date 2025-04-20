using Lab05RQuispe.Models;
        using Lab05RQuispe.UnitOfWork.IUnitOfWork;
        
        namespace Lab05RQuispe.Services;
        
        public class ProfesoreService : IProfesoreService
        {
            private readonly IUnitOfWork _unitOfWork;
        
            public ProfesoreService(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
        
            public async Task<IEnumerable<profesore>> GetAllAsync()
            {
                return await _unitOfWork.Repository<profesore>().GetAllAsync();
            }
        
            public async Task<profesore?> GetByIdAsync(int id)
            {
                return await _unitOfWork.Repository<profesore>().GetByIdAsync(id);
            }
        
            public async Task AddAsync(profesore profesore)
            {
                await _unitOfWork.Repository<profesore>().AddAsync(profesore);
                await _unitOfWork.Complete();
            }
        
            public async Task UpdateAsync(profesore profesore)
            {
                _unitOfWork.Repository<profesore>().Update(profesore);
                await _unitOfWork.Complete();
            }
        
            public async Task DeleteAsync(int id)
            {
                var profesore = await _unitOfWork.Repository<profesore>().GetByIdAsync(id);
                if (profesore != null)
                {
                    _unitOfWork.Repository<profesore>().Remove(profesore);
                    await _unitOfWork.Complete();
                }
            }
        }