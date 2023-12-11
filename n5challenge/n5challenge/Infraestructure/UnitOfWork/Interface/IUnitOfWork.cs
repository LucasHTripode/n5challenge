using n5challenge.Infraestructure.UnitOfWork.Repositories.Interface;
using Nest;

namespace n5challenge.Infraestructure.UnitOfWork.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository();
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
