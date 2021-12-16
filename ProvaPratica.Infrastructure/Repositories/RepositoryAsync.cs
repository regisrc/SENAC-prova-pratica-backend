using Microsoft.EntityFrameworkCore;
using ProvaPratica.Domain.Entities;
using ProvaPratica.Infrastructure.Context;
using ProvaPratica.Infrastructure.Interfaces;

namespace ProvaPratica.Infrastructure.Repositories
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : EntityBase
    {
        private readonly ProvaPraticaContext _dbContext;

        public RepositoryAsync(ProvaPraticaContext context)
        {
            _dbContext = context;
        }

        protected ProvaPraticaContext DbContext => _dbContext;

        public virtual async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<T>> GetActive()
        {
            return _dbContext.Set<T>().Where(x => x.Active).ToListAsync();
        }

        public Task<List<T>> GetAll()
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await _dbContext.Set<T>().FirstAsync(x => Equals(x.Id, id));
        }

        public virtual async Task Update(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
