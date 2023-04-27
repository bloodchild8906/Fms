using System;

namespace Fms.Domain.DbEntity.Auth.Interfaces;

public interface ISession
{
    public Guid Id { get; }

    public DateTime Now { get; }
}