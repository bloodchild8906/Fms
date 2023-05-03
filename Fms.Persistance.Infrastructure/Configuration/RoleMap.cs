using System;
using Fms.Domain.DbEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Configuration;

public class RoleMap
    : IEntityTypeConfiguration<Role>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
    {
             builder.HasMany<User>(user=>user.ReferencedUsers)
                 .WithOne(user=>user.RoleDetail)
                 .HasForeignKey(key=>key.RoleNavigator);
             var role=new Role() { Name = "Admin", RoleId =new Guid("ec340194-c180-456e-b195-31147d29aa12"), PermissionMatrix = "", RoleGroup = null};
             builder.HasData(role);


    }

    public struct Table
    {
        public const string Schema = "dbo";
        public const string Name = "Role";
    }

    public struct Columns
    {
        public const string Id = "Id";
        public const string Name = "Name";
        public const string RoleGroup = "RoleGroup";
        public const string PermissionMatrix = "PermissionMatrix";
    }
}