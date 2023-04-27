using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Fms.Persistance.Infrastructure.Configuration;

public class EmploymentDetailsMap
    : IEntityTypeConfiguration<EmploymentDetails>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<EmploymentDetails> builder)
    {
        builder.ToTable("EmploymentDetails", "dbo");
        builder.HasOne(t => t.User).WithOne((user => user.EmploymentDetails1))
            .HasForeignKey<User>(t => t.EmploymentDetails);

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.CreatedOn)
            .IsRequired()
            .HasColumnName("CreatedOn")
            .HasColumnType("date");

        builder.Property(t => t.JobTitle)
            .IsRequired()
            .HasColumnName("JobTitle")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.EmploymentStatus)
            .IsRequired()
            .HasColumnName("EmploymentStatus")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("((0))");

        builder.Property(t => t.Documentation)
            .HasColumnName("Documentation")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Skills)
            .HasColumnName("Skills")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.TicketAssignments)
            .HasColumnName("TicketAssignments")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.ActiveTicket)
            .HasColumnName("ActiveTicket")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.TravelRangeLimit)
            .HasColumnName("TravelRangeLimit")
            .HasColumnType("float")
            .HasDefaultValueSql("((0))");

        builder.HasOne(t => t.ActiveTicket1)
            .WithMany(t => t.ActiveEmploymentDetails)
            .HasForeignKey(d => d.ActiveTicket)
            .OnDelete(DeleteBehavior.NoAction);

    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "EmploymentDetails";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string CreatedOn = "CreatedOn";
        public const string JobTitle = "JobTitle";
        public const string EmploymentStatus = "EmploymentStatus";
        public const string Documentation = "Documentation";
        public const string Skills = "Skills";
        public const string TicketAssignments = "TicketAssignments";
        public const string ActiveTicket = "ActiveTicket";
        public const string TravelRangeLimit = "TravelRangeLimit";
    }
}