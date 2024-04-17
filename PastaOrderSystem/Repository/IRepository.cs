using System.Linq.Expressions;

namespace WebApi.Repository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter);

        T GetById(Guid id);

        IEnumerable<T> GetAll();

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);

        void Add(T entity, bool saveChanges = true);

        void Update(T entity, bool saveChanges = true);

        void Delete(T entity, bool saveChanges = true);

        Task<T> GetByIdAsync(Guid id);

        Task AddAsync(T entity, bool saveChanges = true);

        void AddRange(IEnumerable<T> entities, bool saveChanges = true);

        Task AddRangeAsync(IEnumerable<T> entities, bool saveChanges = true);

        Task UpdateAsync(T entity, bool saveChanges = true);

        void UpdateRange(IEnumerable<T> entities, bool saveChanges = true);

        Task UpdateRangeAsync(IEnumerable<T> entities, bool saveChanges = true);

        Task DeleteAsync(T entity, bool saveChanges = true);

        void DeleteRange(IEnumerable<T> entities, bool saveChanges = true);

        Task DeleteRangeAsync(IEnumerable<T> entities, bool saveChanges = true);
    }
}