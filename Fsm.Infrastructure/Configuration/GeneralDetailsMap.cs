using Fsm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Infrastructure.Configuration;

public class GeneralDetailsMap
    : IEntityTypeConfiguration<GeneralDetails>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<GeneralDetails> builder)
    {
        builder.ToTable("GeneralDetails", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.FirstName)
            .IsRequired()
            .HasColumnName("FirstName")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.LastName)
            .IsRequired()
            .HasColumnName("LastName")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.DateOfBirth)
            .IsRequired()
            .HasColumnName("DateOfBirth")
            .HasColumnType("date");

        builder.Property(t => t.EmailAddress)
            .IsRequired()
            .HasColumnName("EmailAddress")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.PhoneNumber)
            .IsRequired()
            .HasColumnName("PhoneNumber")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.Address)
            .IsRequired()
            .HasColumnName("Address")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.EmergencyContactName)
            .IsRequired()
            .HasColumnName("EmergencyContactName")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.EmergencyContactNumber)
            .IsRequired()
            .HasColumnName("EmergencyContactNumber")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.EmergencyContactRelation)
            .IsRequired()
            .HasColumnName("EmergencyContactRelation")
            .HasColumnType("varchar(max)");
            
        builder.HasOne(t => t.ReferencedUser).WithOne((user => user.GeneralDetails))
            .HasForeignKey<User>(t => t.PersonalDetails);
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "GeneralDetails";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string FirstName = "FirstName";
        public const string LastName = "LastName";
        public const string DateOfBirth = "DateOfBirth";
        public const string EmailAddress = "EmailAddress";
        public const string PhoneNumber = "PhoneNumber";
        public const string Address = "Address";
        public const string EmergencyContactName = "EmergencyContactName";
        public const string EmergencyContactNumber = "EmergencyContactNumber";
        public const string EmergencyContactRelation = "EmergencyContactRelation";
    }
}