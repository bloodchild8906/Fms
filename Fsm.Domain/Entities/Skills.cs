using System;

namespace Fsm.Domain.Entities;

public class Skills
{
    public Skills()
    {
    }

    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Domain { get; set; }
}