using n5challenge.Core.Entity;
using n5challenge.Infraestructure.EntityFramework.Context;
using n5challenge.Infraestructure.UnitOfWork.Repositories.Interface;

namespace n5challenge.Infraestructure.UnitOfWork.Repositories.Implementation
{
    public class PermissionRepository : BaseRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(N5ChallengeContext dbContext) : base(dbContext)
        {

        }
    }
}
