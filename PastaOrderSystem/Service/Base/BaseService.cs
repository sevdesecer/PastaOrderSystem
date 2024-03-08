using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Repository;
using WebApi.Uow;
using System.Linq.Expressions;

namespace WebApi.Service.Base
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto> where TEntity : class where TDto : class
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly IMapper mapper;
        protected readonly DbContext context;
        protected readonly IUnitOfWork unitOfWork; 

        public BaseService(IMapper mapper, DbContext context)
        {
            repository = new Repository<TEntity>(context);
            this.mapper = mapper;
            this.context = context;
            unitOfWork = new UnitOfWork(context);
        }
        public IEnumerable<TDto> GetAll() =>
            mapper.Map<IEnumerable<TDto>>(repository.GetAll());
        public async Task<IEnumerable<TDto>> GetAllAsync() =>
            mapper.Map<IEnumerable<TDto>>(await repository.GetAllAsync());
        public IEnumerable<TDto> GetByFilter(Expression<Func<TEntity, bool>> filter) =>
            mapper.Map<IEnumerable<TDto>>(repository.GetByFilter(filter));
        public async Task<IEnumerable<TDto>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter) =>
           mapper.Map<IEnumerable<TDto>>(await repository.GetByFilterAsync(filter));
        public TDto GetById(Guid id) =>
           mapper.Map<TDto>(repository.GetById(id));
        public async Task<TDto> GetByIdAsync(Guid id) =>
            mapper.Map<TDto>(await repository.GetByIdAsync(id));
        public void Add(TDto dto, bool saveChanges = true) =>
            repository.Add(mapper.Map<TEntity>(dto), saveChanges);
        public void AddRange(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            repository.AddRange(mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public async Task AddAsync(TDto dto, bool saveChanges = true) =>
            await repository.AddAsync(mapper.Map<TEntity>(dto), saveChanges);
        public async Task AddRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            await repository.AddRangeAsync(mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public void Update(TDto dto, bool saveChanges = true) =>
            repository.Update(mapper.Map<TEntity>(dto), saveChanges);
        public void UpdateRange(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            repository.UpdateRange(mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public async Task UpdateAsync(TDto dto, bool saveChanges = true) =>
            await repository.UpdateAsync(mapper.Map<TEntity>(dto), saveChanges);
        public async Task UpdateRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            await repository.UpdateRangeAsync(mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public void Delete(TDto dto, bool saveChanges = true) =>
            repository.Delete(mapper.Map<TEntity>(dto), saveChanges);
        public void DeleteRange(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            repository.DeleteRange(mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public async Task DeleteAsync(TDto dto, bool saveChanges = true) =>
            await repository.DeleteAsync(mapper.Map<TEntity>(dto), saveChanges);
        public async Task DeleteRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            await repository.DeleteRangeAsync(mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
    }
}

