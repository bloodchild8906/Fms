using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class SkillsMap
    : IEntityTypeConfiguration<Skills>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Skills> builder)
    {
        builder.ToTable("Skills", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Domain)
            .IsRequired()
            .HasColumnName("Domain")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Skills";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Name = "Name";
        public const string Domain = "Domain";
    }
}