using n5challenge.Application.Model;
using n5challenge.Handlers.Commands;

namespace n5challenge.Core.Entity
{
    public record Permission : IEntity
    {        
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }

        public Permission() { }

        public static explicit operator Permission(RequestPermissionsCommand requestPermissionsCommand)
        {
            return new Permission
            {
                EmployeeForename = requestPermissionsCommand.EmployeeForename,
                EmployeeSurname = requestPermissionsCommand.EmployeeSurname,
                PermissionType = requestPermissionsCommand.PermissionType,
                PermissionDate = DateTime.Now
            };
        }
    }
}
