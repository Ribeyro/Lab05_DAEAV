using System.Linq.Expressions;
        using Lab05RQuispe.Models;
        using Lab05RQuispe.Repository.IRepository;
        using Microsoft.EntityFrameworkCore;
        
        namespace Lab05RQuispe.Repository;
        
        public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
        {
            private readonly Lab05Context _context;
            private readonly DbSet<TEntity> _dbSet;
        
            public GenericRepository(Lab05Context context)
            {
                _context = context;
                _dbSet = context.Set<TEntity>();
            }
        
            public async Task<IEnumerable<TEntity>> GetAllAsync()
            {
                return await _dbSet.ToListAsync();
            }
        
            public async Task<TEntity?> GetByIdAsync(object id)
            {
                return await _dbSet.FindAsync(id);
            }
        
            public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            {
                return await _dbSet.Where(predicate).ToListAsync();
            }
        
            public async Task AddAsync(TEntity entity)
            {
                await _dbSet.AddAsync(entity);
            }
        
            public void Add(TEntity entity)
            {
                _dbSet.Add(entity);
            }
        
            public void Update(TEntity entity)
            {
                _dbSet.Update(entity);
            }
        
            public void Remove(TEntity entity)
            {
                _dbSet.Remove(entity);
            }
        }