using AutoMapper;
using MediatR;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.UnitOfWork.Interface;
using System.Security.Permissions;

namespace n5challenge.Handlers.Commands
{
    public class ModifyPermissionsCommand : IRequest<Permission>
    {
        public int Id { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionType { get; set; }

        public ModifyPermissionsCommand() { }
    }

    public class ModifyPermissionsCommandHandler : IRequestHandler<ModifyPermissionsCommand, Permission>
    {
        private readonly IUnitOfWork _uow;

        public ModifyPermissionsCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Permission> Handle(ModifyPermissionsCommand request, CancellationToken cancellationToken)
        {
            var permission = await _uow.Repository().GetById<Permission>(request.Id);

            if (permission is null)
                return default;

            permission.EmployeeForename = request.EmployeeForename;
            permission.EmployeeSurname = request.EmployeeSurname;
            permission.PermissionType = request.PermissionType;

            await _uow.CommitAsync();

            return permission;
        }
    }
}
