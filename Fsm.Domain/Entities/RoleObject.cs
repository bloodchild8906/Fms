using System;

namespace Fsm.Domain.Entities;

public class RoleObject
{
    public RoleObject()
    {
    }

    public Guid Id { get; set; }

    public Guid Role { get; set; }

    public string ObjectName { get; set; }

    public Guid Group { get; set; }

    public RoleGroup GroupRoleGroup { get; set; }
}