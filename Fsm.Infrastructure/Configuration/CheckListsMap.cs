using Fsm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Infrastructure.Configuration;

public class CheckListsMap
    : IEntityTypeConfiguration<CheckLists>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CheckLists> builder)
    {
        builder.ToTable("CheckLists", "dbo");

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

        builder.Property(t => t.Notes)
            .HasColumnName("Notes")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);


        builder.Property(t => t.IsComplete)
            .HasColumnName("IsComplete")
            .HasColumnType("bit")
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.CompletedOn)
            .HasColumnName("CompletedOn")
            .HasColumnType("date");

    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "CheckLists";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Name = "Name";
        public const string Notes = "Notes";
        public const string RelatedDocuments = "RelatedDocuments";
        public const string IsComplete = "IsComplete";
        public const string CompletedOn = "CompletedOn";
        public const string ActivityList = "ActivityList";
    }
}