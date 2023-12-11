using Microsoft.EntityFrameworkCore;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.EntityFramework.ConfigureEntity;


namespace n5challenge.Infraestructure.EntityFramework.Context
{
    public class N5ChallengeContext : DbContext
    {
        public N5ChallengeContext() { }
        public N5ChallengeContext(DbContextOptions<N5ChallengeContext> options) : base(options) { }

        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionType> PermissionTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            StaticConfigureEntity<Permission, PermissionConfigure>.Configure(modelBuilder);
            StaticConfigureEntity<PermissionType, PermissionTypeConfigure>.Configure(modelBuilder);            
        }           

    }
}
