using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class RoleGroupMap
    : IEntityTypeConfiguration<RoleGroup>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<RoleGroup> builder)
    {
        builder.ToTable("RoleGroup", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("nvarchar(max)");
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "RoleGroup";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Name = "Name";
    }
}