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
        
            public async Task<IEnumerable<Profesore>> GetAllAsync()
            {
                return await _unitOfWork.Repository<Profesore>().GetAllAsync();
            }
        
            public async Task<Profesore?> GetByIdAsync(int id)
            {
                return await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
            }
        
            public async Task AddAsync(Profesore profesore)
            {
                await _unitOfWork.Repository<Profesore>().AddAsync(profesore);
                await _unitOfWork.Complete();
            }
        
            public async Task UpdateAsync(Profesore profesore)
            {
                _unitOfWork.Repository<Profesore>().Update(profesore);
                await _unitOfWork.Complete();
            }
        
            public async Task DeleteAsync(int id)
            {
                var profesore = await _unitOfWork.Repository<Profesore>().GetByIdAsync(id);
                if (profesore != null)
                {
                    _unitOfWork.Repository<Profesore>().Remove(profesore);
                    await _unitOfWork.Complete();
                }
            }
        }