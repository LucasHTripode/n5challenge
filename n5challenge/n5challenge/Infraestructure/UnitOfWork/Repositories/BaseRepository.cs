using Microsoft.EntityFrameworkCore;
using n5challenge.Infraestructure.EntityFramework.Context;

namespace n5challenge.Infraestructure.UnitOfWork.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected readonly N5ChallengeContext _n5ChallengeContext;

        public BaseRepository(N5ChallengeContext n5ChallengeContext)
        {
            _n5ChallengeContext = n5ChallengeContext;
        }
                
        public virtual async Task<IEnumerable<T>> List()
        {
            return await _n5ChallengeContext.Set<T>().ToListAsync();
        }

        public virtual async Task Create(T entity)
        {
            await _n5ChallengeContext.Set<T>().AddAsync(entity);
        }

        public virtual async Task Edit(T entity)
        {
            _n5ChallengeContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual async Task<bool> Exist(params object[] keyValues)
        {
            var permission = await _n5ChallengeContext.Set<T>().FindAsync(keyValues);

            if (permission != null)
                return true;

            return false;
        }

    }
}
