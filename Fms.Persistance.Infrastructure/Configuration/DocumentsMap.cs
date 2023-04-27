using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class DocumentsMap
    : IEntityTypeConfiguration<Documents>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Documents> builder)
    {
        builder.ToTable("Documents", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.File)
            .IsRequired()
            .HasColumnName("file")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.FileType)
            .IsRequired()
            .HasColumnName("FileType")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.RequiresAction)
            .HasColumnName("RequiresAction")
            .HasColumnType("bit")
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.TimeSensitive)
            .HasColumnName("TimeSensitive")
            .HasColumnType("bit")
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.IsComplete)
            .HasColumnName("IsComplete")
            .HasColumnType("bit")
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.ActionType)
            .IsRequired()
            .HasColumnName("ActionType")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.DueOn)
            .HasColumnName("DueOn")
            .HasColumnType("date");

        builder.Property(t => t.SentOn)
            .IsRequired()
            .HasColumnName("SentOn")
            .HasColumnType("date");

        builder.Property(t => t.UpdatedOn)
            .IsRequired()
            .HasColumnName("UpdatedOn")
            .HasColumnType("date");
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Documents";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string File = "file";
        public const string FileType = "FileType";
        public const string RequiresAction = "RequiresAction";
        public const string TimeSensitive = "TimeSensitive";
        public const string IsComplete = "IsComplete";
        public const string ActionType = "ActionType";
        public const string DueOn = "DueOn";
        public const string SentOn = "SentOn";
        public const string UpdatedOn = "UpdatedOn";
    }
}