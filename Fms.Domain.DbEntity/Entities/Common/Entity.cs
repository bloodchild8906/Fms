using System;
using System.ComponentModel.DataAnnotations;

namespace Fms.Domain.DbEntity.Entities.Common;

public abstract class Entity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
}