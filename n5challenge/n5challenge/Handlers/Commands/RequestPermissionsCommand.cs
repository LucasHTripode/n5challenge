using AutoMapper;
using MediatR;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.UnitOfWork.Interface;

namespace n5challenge.Handlers.Commands
{
    public class RequestPermissionsCommand : MediatR.IRequest<Permission>
    {
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionType { get; set; }
        public RequestPermissionsCommand() { }
    }

    public class RequestPermissionsCommandHandler : IRequestHandler<RequestPermissionsCommand, Permission>
    {
        private readonly IUnitOfWork _uow;

        public RequestPermissionsCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Permission> Handle(RequestPermissionsCommand request, CancellationToken cancellationToken)
        {
            var exist = await _uow.Repository()
                                   .Exist<Permission>(x => x.EmployeeSurname == request.EmployeeSurname &&
                                                           x.EmployeeSurname == request.EmployeeSurname &&
                                                           x.PermissionType == request.PermissionType);
            if (exist)
                return default;

            var existType = await _uow.Repository().Exist<PermissionType>(x => x.Id == request.PermissionType);

            if (!existType)
                return default;

            var permission = (Permission)request;

            var permissionAdd = _uow.Repository().Add<Permission>(permission);
            await _uow.CommitAsync();

            return permissionAdd;
        }
    }
}
