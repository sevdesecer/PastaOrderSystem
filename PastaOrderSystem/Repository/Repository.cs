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

        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter) { return _dbSet.Where(filter).ToList();}

        // Retrieve an entity by its id
        public T GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        // Retrieve an entity asynchronously by its id
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Retrieve all entities
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        // Retrieve all entities asynchronously
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // Add an entity
        public void Add(T entity, bool saveChanges = true)
        {
            _dbSet.Add(entity);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Add an entity asynchronously
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

        // Update an entity
        public void Update(T entity, bool saveChanges = true)
        {
            _context.Update(entity);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Update an entity asynchronously
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

        // Delete an entity
        public void Delete(T entity, bool saveChanges = true)
        {
            _dbSet.Remove(entity);
            if (saveChanges)
                _context.SaveChanges();
        }

        // Delete an entity asynchronously
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
