using System;
using System.Collections.Generic;

namespace Fsm.Domain.Entities;

public class ActivityLog
{
    public ActivityLog()
    {
    }

    public Guid Id { get; set; }

    public DateTime CreatedOn { get; set; }

    public string Notes { get; set; }

    public string Status { get; set; }

    public ICollection<Documents> Attachments { get; set; } = new List<Documents>();
}