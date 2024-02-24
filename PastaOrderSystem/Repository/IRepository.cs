using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace PastaOrderSystem.Repository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetByFilter(Expression<Func<T, bool>> filter);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
        void Add(T entity, bool saveChanges = true);
        void Update(T entity, bool saveChanges = true);
        void Delete(T entity, bool saveChanges = true);
    }
}
