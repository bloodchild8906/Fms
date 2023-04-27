using System;

namespace Fms.Application.Core.Features.Auth.Authenticate;

public record Jwt
{
    public string Token { get; init; } = null!;
    public DateTime ExpDate { get; init; }
}