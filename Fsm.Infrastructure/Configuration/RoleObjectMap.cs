using Fsm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Infrastructure.Configuration;

public class RoleObjectMap
    : IEntityTypeConfiguration<RoleObject>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleObject> builder)
    {
        builder.ToTable("RoleObject", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Role)
            .IsRequired()
            .HasColumnName("Role")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.ObjectName)
            .HasColumnName("ObjectName")
            .HasColumnType("nvarchar(max)");

        builder.Property(t => t.Group)
            .IsRequired()
            .HasColumnName("Group")
            .HasColumnType("uniqueidentifier");

        builder.HasOne(t => t.GroupRoleGroup)
            .WithMany(t => t.GroupRoleObjects)
            .HasForeignKey(d => d.Group)
            .HasConstraintName("FK__RoleObjec__Group__628FA481");
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "RoleObject";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Role = "Role";
        public const string ObjectName = "ObjectName";
        public const string Group = "Group";
    }
}