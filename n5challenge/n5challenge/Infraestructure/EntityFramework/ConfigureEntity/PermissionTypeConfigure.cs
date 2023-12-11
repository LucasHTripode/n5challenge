using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.EntityFramework.Context;

namespace n5challenge.Infraestructure.EntityFramework.ConfigureEntity
{
    public class PermissionTypeConfigure : AbstractConfigureEntity<PermissionType>
    {
        public override void Configure(EntityTypeBuilder<PermissionType> entity)
        {
            entity.ToTable("PermissionType");
            entity.HasKey(e => e.Id);

            entity.Property(p => p.Id).HasColumnName("Id").HasColumnType("NUMBER(10)").IsRequired();
            entity.Property(p => p.Description).HasColumnName("Description").HasColumnType("VARCHAR(100)");
        }
    }
}
