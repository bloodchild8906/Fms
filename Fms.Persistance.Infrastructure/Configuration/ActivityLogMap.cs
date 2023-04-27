using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class ActivityLogMap
    : IEntityTypeConfiguration<ActivityLog>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ActivityLog> builder)
    {
        builder.ToTable("ActivityLog", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.CreatedOn)
            .IsRequired()
            .HasColumnName("CreatedOn")
            .HasColumnType("date");

        builder.Property(t => t.Notes)
            .IsRequired()
            .HasColumnName("Notes")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("Status")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("((0))");

    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "ActivityLog";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string CreatedOn = "CreatedOn";
        public const string Notes = "Notes";
        public const string Status = "Status";
        public const string Attachments = "Attachments";
    }
}