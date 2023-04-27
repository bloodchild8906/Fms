using System;

namespace Fsm.Domain.Auth.Interfaces;

public interface ISession
{
    public Guid Id { get; }

    public DateTime Now { get; }
}