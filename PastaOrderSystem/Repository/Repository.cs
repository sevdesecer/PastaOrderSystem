using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PastaOrderSystem.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>(); 
        }

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter) =>
            _dbSet.Where(filter).ToList();
        public async Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter) =>
            await _dbSet.Where(filter).ToListAsync() ?? throw new ArgumentNullException("Could not find a record with this query.");


        // Retrieves an entity by its id
        public T GetById(Guid id) =>
            _dbSet.Find(id) ?? throw new ArgumentNullException("Could not find a record with this id.");


        // Retrieves an entity asynchronously by its id
        public async Task<T> GetByIdAsync(Guid id) =>
            await _dbSet.FindAsync(id) ?? throw new ArgumentNullException("Could not find a record with this id.");

        // Retrieves all entities
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // Retrieves all entities asynchronously
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Adds an entity
        public void Add(T entity, bool saveChanges = true)
        {
            _dbSet.Add(entity);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Adds an entity asynchronously
        public async Task AddAsync(T entity, bool saveChanges = true)
        {
            await _dbSet.AddAsync(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        // Adds range of entities
        public void AddRange(IEnumerable<T> entities, bool saveChanges = true)
        {
            _dbSet.AddRange(entities);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Adds range of entities asynchronously
        public async Task AddRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
        {
            await _dbSet.AddRangeAsync(entities);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        // Updates an entity
        public void Update(T entity, bool saveChanges = true)
        {
            _context.Update(entity);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Updates an entity asynchronously
        public async Task UpdateAsync(T entity, bool saveChanges = true)
        {
            _context.Update(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        // Updates range of entities
        public void UpdateRange(IEnumerable<T> entities, bool saveChanges = true)
        {
            _context.UpdateRange(entities);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Updates range of entities asynchronously
        public async Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
        {
            _context.UpdateRange(entities);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        // Deletes an entity
        public void Delete(T entity, bool saveChanges = true)
        {
            _dbSet.Remove(entity);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Deletes an entity asynchronously
        public async Task DeleteAsync(T entity, bool saveChanges = true)
        {
            _dbSet.Remove(entity);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        // Deletes range of entities
        public void DeleteRange(IEnumerable<T> entities, bool saveChanges = true)
        {
            _dbSet.RemoveRange(entities);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Deletes range of entities asynchronously
        public async Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true)
        {
            _dbSet.RemoveRange(entities);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
 
    }
}
