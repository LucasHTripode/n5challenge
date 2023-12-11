namespace n5challenge.Application.Model
{
    public class RequestPermissionModel
    {
        public string EmployeeForename { get; set; }
        public string EmployeeSurname { get; set; }
        public int PermissionType { get; set; }

        public RequestPermissionModel() { }
    }
}
