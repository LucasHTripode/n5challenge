using n5challenge.Core.Entity;

namespace n5challenge.Business.Interface
{
    public interface IPermissionBusiness
    {
        Task<IEnumerable<Permission>> GetPermissionsAsync();
        Task ModifyPermissionAsync(Permission permission);
        Task<Permission> RequestPermissionAsync(Permission permission);
        Task<bool> ExistAsync(Permission permission);
    }
}
