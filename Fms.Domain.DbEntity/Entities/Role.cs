using System;
using System.Collections.Generic;

namespace Fms.Domain.DbEntity.Entities;

public sealed class Role
{
    

    public Guid RoleId { get; set; }

    public string? Name { get; set; }

    public Guid? RoleGroup { get; set; }

    public string? PermissionMatrix { get; set; }
    
    public ICollection<User> ReferencedUsers { get; } = new List<User>();

   // public ICollection<Ticket> CanBeApprovedBysTickets { get; set; }

   // public RoleGroup? RoleGroup1 { get; set; }
}