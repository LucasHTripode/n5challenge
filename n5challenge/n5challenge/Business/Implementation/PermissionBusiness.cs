using n5challenge.Business.Interface;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.UnitOfWork.Interface;

namespace n5challenge.Business.Implementation
{
    public class PermissionBusiness : IPermissionBusiness
    {
        readonly IUnitOfWork _unitOfWork;
        public PermissionBusiness(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            var list = await _unitOfWork.Permissions.List();
            return list;
        }

        public async Task<bool> ExistAsync(Permission permission)
        {
            return await _unitOfWork.Permissions.Exist(permission.Id);
        }

        public async Task ModifyPermissionAsync(Permission permission)
        {
            try
            {
                await _unitOfWork.Begin();               
                await _unitOfWork.Permissions.Edit(permission);
                await _unitOfWork.Commit();
            }
            catch (Exception exception)
            {
                await _unitOfWork.Rollback();
                throw exception;
            }
        }

        public async Task<Permission> RequestPermissionAsync(Permission permission)
        {
            try
            {
                await _unitOfWork.Begin();
                await _unitOfWork.Permissions.Create(permission);
                await _unitOfWork.Commit();

                return permission;
            }
            catch (Exception exception)
            {
                await _unitOfWork.Rollback();
                throw exception;
            }
        }
    }
}
