using System;

namespace Fsm.Application.Features.Users;

public record GetUserResponse
{
    public Guid Id { get; init; }

    public string Username { get; init; } = null!;

    public bool IsAdmin { get; init; }
}