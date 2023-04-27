using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class ActivityMap
    : IEntityTypeConfiguration<Activity>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable("Activity", "dbo");

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

        builder.Property(t => t.Description)
            .IsRequired()
            .HasColumnName("Description")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);


        builder.Property(t => t.StartedOn)
            .IsRequired()
            .HasColumnName("StartedOn")
            .HasColumnType("date");

        builder.Property(t => t.Notes)
            .HasColumnName("Notes")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);


        builder.Property(t => t.IsComplete)
            .HasColumnName("IsComplete")
            .HasColumnType("bit")
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.CompletedOn)
            .HasColumnName("completedOn")
            .HasColumnType("date");

    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Activity";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Name = "Name";
        public const string Description = "Description";
        public const string Skillsrequired = "Skillsrequired";
        public const string StartedOn = "StartedOn";
        public const string Notes = "Notes";
        public const string RelatedDocuments = "RelatedDocuments";
        public const string IsComplete = "IsComplete";
        public const string CompletedOn = "completedOn";
        public const string TaskLog = "TaskLog";
    }
}