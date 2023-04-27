using System;

namespace Fms.Domain.DbEntity.Entities;

public class ContactDomainRoles
{
    public ContactDomainRoles()
    {
    }

    public Guid Id { get; set; }

    public string Domain { get; set; }

    public Guid RoleGroup { get; set; }

    public string CustomerAccount { get; set; }

    public RoleGroup RoleGroup1 { get; set; }
}