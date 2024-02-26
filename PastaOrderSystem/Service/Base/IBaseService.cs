using System.Linq.Expressions;

namespace PastaOrderSystem.Service.Base
{
    public interface IBaseService<TEntity, TDto> where TEntity : class where TDto : class
    {
        void Add(TDto dto, bool saveChanges = true);
        Task AddAsync(TDto dto, bool saveChanges = true);
        void AddRange(IEnumerable<TDto> dtos, bool saveChanges = true);
        Task AddRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true);
        void Delete(TDto dto, bool saveChanges = true);
        Task DeleteAsync(TDto dto, bool saveChanges = true);
        void DeleteRange(IEnumerable<TDto> dtos, bool saveChanges = true);
        Task DeleteRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true);
        IEnumerable<TDto> GetAll();
        Task<IEnumerable<TDto>> GetAllAsync();
        IEnumerable<TDto> GetByFilter(Expression<Func<TEntity, bool>> filter);
        Task<IEnumerable<TDto>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter);
        TDto GetById(Guid id);
        Task<TDto> GetByIdAsync(Guid id);
        void Update(TDto dto, bool saveChanges = true);
        Task UpdateAsync(TDto dto, bool saveChanges = true);
        void UpdateRange(IEnumerable<TDto> dtos, bool saveChanges = true);
        Task UpdateRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true);
    }
}
