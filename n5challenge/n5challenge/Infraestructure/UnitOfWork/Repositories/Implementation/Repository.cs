using Microsoft.EntityFrameworkCore;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.EntityFramework.Context;
using n5challenge.Infraestructure.UnitOfWork.Repositories.Interface;
using Nest;
using System.Linq.Expressions;
using System.Security.Principal;

namespace n5challenge.Infraestructure.UnitOfWork.Repositories.Implementation
{
    public class Repository : IRepository
    {
        private readonly N5ChallengeContext _dbContext;

        public Repository(N5ChallengeContext n5ChallengeContext)
        {
            _dbContext = n5ChallengeContext;
        }

        public async Task<T?> GetById<T>(int id) where T : IEntity
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IQueryable<T> FindQueryable<T>(Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : IEntity
        {
            var query = _dbContext.Set<T>().Where(expression);
            return orderBy != null ? orderBy(query) : query;
        }

        public Task<List<T>> FindListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>,
            IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
            where T : class
        {
            var query = expression != null ? _dbContext.Set<T>().Where(expression) : _dbContext.Set<T>();
            return orderBy != null
                ? orderBy(query).ToListAsync(cancellationToken)
                : query.ToListAsync(cancellationToken);
        }

        public Task<List<T>> FindAllAsync<T>() where T : IEntity
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public Task<bool> Exist<T>(Expression<Func<T, bool>> expression) where T : IEntity
        {
            var any = _dbContext.Set<T>().AnyAsync(expression);

            return any;
        }

        public T Add<T>(T entity) where T : IEntity
        {
            return _dbContext.Set<T>().Add(entity).Entity;
        }

        public void Update<T>(T entity) where T : IEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange<T>(IEnumerable<T> entities) where T : IEntity
        {
            _dbContext.Set<T>().UpdateRange(entities);
        }

        public void Delete<T>(T entity) where T : IEntity
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
