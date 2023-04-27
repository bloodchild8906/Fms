using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class ContactDomainRolesMap
    : IEntityTypeConfiguration<ContactDomainRoles>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ContactDomainRoles> builder)
    {
        builder.ToTable("ContactDomainRoles", "dbo");

        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
            .IsRequired()
            .HasColumnName("Id")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.Domain)
            .IsRequired()
            .HasColumnName("Domain")
            .HasColumnType("varchar(1)")
            .HasMaxLength(1);

        builder.Property(t => t.RoleGroup)
            .IsRequired()
            .HasColumnName("RoleGroup")
            .HasColumnType("uniqueidentifier");

        builder.Property(t => t.CustomerAccount)
            .IsRequired()
            .HasColumnName("CustomerAccount")
            .HasColumnType("varchar(1)")
            .HasMaxLength(1);

        builder.HasOne(t => t.RoleGroup1)
            .WithMany(t => t.ContactDomainRoles)
            .HasForeignKey(d => d.RoleGroup)
            .HasConstraintName("FK__ContactDo__RoleG__5FB337D6");
    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "ContactDomainRoles";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Domain = "Domain";
        public const string RoleGroup = "RoleGroup";
        public const string CustomerAccount = "CustomerAccount";
    }
}