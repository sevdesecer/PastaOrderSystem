using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PastaOrderSystem.Repository;
using System.Linq.Expressions;

namespace PastaOrderSystem.Service.Base
{
    public class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto> where TEntity : class where TDto : class
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly DbContext _context;

        public BaseService(IMapper mapper, DbContext context)
        {
            _repository = new Repository<TEntity>(context);
            _mapper = mapper;
            _context = context;
        }
        public IEnumerable<TDto> GetAll() =>
            _mapper.Map<IEnumerable<TDto>>(_repository.GetAll());
        public async Task<IEnumerable<TDto>> GetAllAsync() =>
            _mapper.Map<IEnumerable<TDto>>(await _repository.GetAllAsync());
        public IEnumerable<TDto> GetByFilter(Expression<Func<TEntity, bool>> filter) =>
            _mapper.Map<IEnumerable<TDto>>(_repository.GetByFilter(filter));
        public async Task<IEnumerable<TDto>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter) =>
           _mapper.Map<IEnumerable<TDto>>(await _repository.GetByFilterAsync(filter));
        public TDto GetById(Guid id) =>
           _mapper.Map<TDto>(_repository.GetById(id));
        public async Task<TDto> GetByIdAsync(Guid id) =>
            _mapper.Map<TDto>(await _repository.GetByIdAsync(id));
        public void Add(TDto dto, bool saveChanges = true) =>
            _repository.Add(_mapper.Map<TEntity>(dto), saveChanges);
        public void AddRange(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            _repository.AddRange(_mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public async Task AddAsync(TDto dto, bool saveChanges = true) =>
            await _repository.AddAsync(_mapper.Map<TEntity>(dto), saveChanges);
        public async Task AddRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            await _repository.AddRangeAsync(_mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public void Update(TDto dto, bool saveChanges = true) =>
            _repository.Update(_mapper.Map<TEntity>(dto), saveChanges);
        public void UpdateRange(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            _repository.UpdateRange(_mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public async Task UpdateAsync(TDto dto, bool saveChanges = true) =>
            await _repository.UpdateAsync(_mapper.Map<TEntity>(dto), saveChanges);
        public async Task UpdateRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            await _repository.UpdateRangeAsync(_mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public void Delete(TDto dto, bool saveChanges = true) =>
            _repository.Delete(_mapper.Map<TEntity>(dto), saveChanges);
        public void DeleteRange(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            _repository.DeleteRange(_mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
        public async Task DeleteAsync(TDto dto, bool saveChanges = true) =>
            await _repository.DeleteAsync(_mapper.Map<TEntity>(dto), saveChanges);
        public async Task DeleteRangeAsync(IEnumerable<TDto> dtos, bool saveChanges = true) =>
            await _repository.DeleteRangeAsync(_mapper.Map<IEnumerable<TEntity>>(dtos), saveChanges);
    }
}

