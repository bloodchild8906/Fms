using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class TicketMap
    : IEntityTypeConfiguration<Ticket>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ticket> builder)
    {
        builder.ToTable("Ticket", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Referencenumber)
            .IsRequired()
            .HasColumnName("Referencenumber")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);


        builder.Property(t => t.Client)
            .IsRequired()
            .HasColumnName("Client")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Approvedon)
            .HasColumnName("Approvedon")
            .HasColumnType("date");


        builder.Property(t => t.ApprovedBy)
            .HasColumnName("ApprovedBy")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.CreatedOn)
            .HasColumnName("CreatedOn")
            .HasColumnType("date");

        builder.Property(t => t.CreatedBy)
            .HasColumnName("CreatedBy")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Requestedon)
            .HasColumnName("Requestedon")
            .HasColumnType("date");

        builder.Property(t => t.RequestedBy)
            .HasColumnName("RequestedBy")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Notes)
            .HasColumnName("Notes")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255);

        builder.Property(t => t.Status)
            .IsRequired()
            .HasColumnName("Status")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("((0))");

        // builder.HasMany(t =>t.CheckListsCollection).WithOne(t=>t.ReferencedTicket);
        // builder.HasOne(t =>t.SkillsCollection).WithMany(t=>t);

        builder.HasOne(t => t.ApprovedByUser)
            .WithMany(t => t.ApprovedByTickets)
            .HasForeignKey(d => d.ApprovedBy)
            .HasConstraintName("FK__Ticket__Approved__5441852A");

        builder.HasOne(t => t.CanBeApprovedBysRole)
            .WithMany(t => t.CanBeApprovedBysTickets)
            .HasForeignKey(d => d.CanBeApprovedByRoles)
            .HasConstraintName("FK__Ticket__CanBeApp__534D60F1");

        builder.HasOne(t => t.CreatedByUser)
            .WithMany(t => t.CreatedByTickets)
            .HasForeignKey(d => d.CreatedBy)
            .HasConstraintName("FK__Ticket__CreatedB__5535A963");

        builder.HasOne(t => t.RequestedByUser)
            .WithMany(t => t.RequestedByTickets)
            .HasForeignKey(d => d.RequestedBy)
            .HasConstraintName("FK__Ticket__Requeste__5629CD9C");
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Ticket";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Referencenumber = "Referencenumber";
        public const string Skillsrequired = "Skillsrequired";
        public const string Checklists = "Checklists";
        public const string Client = "Client";
        public const string Approvedon = "Approvedon";
        public const string CanBeApprovedByRoles = "CanBeApprovedByRoles";
        public const string ApprovedBy = "ApprovedBy";
        public const string CreatedOn = "CreatedOn";
        public const string CreatedBy = "CreatedBy";
        public const string Requestedon = "Requestedon";
        public const string RequestedBy = "RequestedBy";
        public const string Notes = "Notes";
        public const string Status = "Status";
    }
}