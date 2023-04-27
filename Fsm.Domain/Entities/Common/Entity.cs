using System;
using System.ComponentModel.DataAnnotations;

namespace Fsm.Domain.Entities.Common;

public abstract class Entity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
}