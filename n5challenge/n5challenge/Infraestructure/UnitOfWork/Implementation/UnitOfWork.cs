using n5challenge.Infraestructure.EntityFramework.Context;
using n5challenge.Infraestructure.UnitOfWork.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using n5challenge.Infraestructure.UnitOfWork.Repositories.Interface;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.UnitOfWork.Repositories.Implementation;
using Nest;

namespace n5challenge.Infraestructure.UnitOfWork.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        readonly N5ChallengeContext _n5ChallengeContext;

        public UnitOfWork(N5ChallengeContext n5ChallengeContext) 
        {
            _n5ChallengeContext = n5ChallengeContext;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IRepository Repository()
        {
            return new Repository(_n5ChallengeContext);
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _n5ChallengeContext.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _n5ChallengeContext.Dispose();
            _disposed = true;
        }


    }
}
