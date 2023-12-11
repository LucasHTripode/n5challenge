using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using n5challenge.Core.Entity;
using n5challenge.Infraestructure.EntityFramework.Context;
using System;


namespace n5challenge.Infraestructure.EntityFramework.ConfigureEntity
{
    public class PermissionConfigure : AbstractConfigureEntity<Permission>
    {
        public override void Configure(EntityTypeBuilder<Permission> entity)
        {
            entity.ToTable("Permission");
            entity.HasKey(e => e.Id);

            entity.Property(p => p.Id).HasColumnName("Id").HasColumnType("NUMBER(10)").IsRequired();
            entity.Property(p => p.EmployeeForename).HasColumnName("EmployeeForename").HasColumnType("VARCHAR(100)");
            entity.Property(p => p.EmployeeSurname).HasColumnName("EmployeeSurname").HasColumnType("VARCHAR(100)");
            entity.Property(p => p.PermissionType).HasColumnName("PermissionType").HasColumnType("NUMBER(10)");
            entity.Property(p => p.PermissionDate).HasColumnName("PermissionDate").HasColumnType("DATE");

            entity.HasOne(x => x.PermissionTypeObject).WithMany(x => x.Permissions).HasForeignKey(x => x.PermissionType);
        }
    }
}
