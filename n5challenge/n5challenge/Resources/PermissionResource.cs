using n5challenge.Application.Model;
using n5challenge.Core.Entity;

namespace n5challenge.Resources
{
    public class PermissionResource
    {
        public int Id { get; set; }
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionType { get; set; }
        public DateTime PermissionDate { get; set; }
        
    }

}
