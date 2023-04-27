using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class UserMap
    : IEntityTypeConfiguration<User>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Username)
            .IsRequired()
            .HasColumnName("Username")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasColumnType("varchar(max)");

        builder.Property(t => t.PersonalDetails)
            .IsRequired()
            .HasColumnName("PersonalDetails")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.EmploymentDetails)
            .IsRequired()
            .HasColumnName("EmploymentDetails")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Role)
            .IsRequired()
            .HasColumnName("Role")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.UserType)
            .IsRequired()
            .HasColumnName("UserType")
            .HasColumnType("nvarchar(255)")
            .HasMaxLength(255)
            .HasDefaultValueSql("((0))");

            

        builder.HasOne(t => t.GeneralDetails)
            .WithOne(t => t.ReferencedUser)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK__User__PersonalDe__5CD6CB2B");

        builder.HasOne(t => t.Role1)
            .WithMany(t => t.Users)
            .HasForeignKey(d => d.Role)
            .OnDelete(DeleteBehavior.NoAction)
            .HasConstraintName("FK__User__Role__5EBF139D");
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "User";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Username = "Username";
        public const string Password = "Password";
        public const string GeneralDetails = "PersonalDetails";
        public const string EmploymentDetails = "EmploymentDetails";
        public const string Role = "Role";
        public const string UserType = "UserType";
    }
}