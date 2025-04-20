using System.Linq.Expressions;
    
    namespace Lab05RQuispe.Repository.IRepository;
    
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    
        Task AddAsync(TEntity entity); // Insert and wait for Save
        void Add(TEntity entity);      // Insert without Save (use UoW.Complete later)
    
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }