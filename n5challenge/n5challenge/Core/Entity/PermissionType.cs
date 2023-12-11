namespace n5challenge.Core.Entity
{
    public record PermissionType : IEntity
    {
        public string Description { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }

        public PermissionType() {}
    }
}
