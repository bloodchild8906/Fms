using Fsm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Infrastructure.Configuration;

public class RoleMap
    : IEntityTypeConfiguration<Role>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Role", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.RoleGroup)
            .HasColumnName("RoleGroup")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.PermissionMatrix)
            .IsRequired()
            .HasColumnName("PermissionMatrix")
            .HasColumnType("varchar(max)");

        builder.HasOne(t => t.RoleGroup1)
            .WithMany(t => t.Roles)
            .HasForeignKey(d => d.RoleGroup)
            .HasConstraintName("FK__Role__RoleGroup__60A75C0F");
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Role";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Name = "Name";
        public const string RoleGroup = "RoleGroup";
        public const string PermissionMatrix = "PermissionMatrix";
    }
}