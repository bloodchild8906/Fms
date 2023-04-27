using System;
using System.Collections.Generic;

namespace Fms.Domain.DbEntity.Entities;

public class Role
{
    public Role()
    {
        CanBeApprovedBysTickets = new HashSet<Ticket>();
        Users = new HashSet<User>();
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public Guid? RoleGroup { get; set; }

    public string PermissionMatrix { get; set; }

    public ICollection<Ticket> CanBeApprovedBysTickets { get; set; }

    public RoleGroup RoleGroup1 { get; set; }

    public ICollection<User> Users { get; set; }
}