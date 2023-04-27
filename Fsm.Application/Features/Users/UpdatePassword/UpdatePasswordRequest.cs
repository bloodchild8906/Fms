using System;
using Ardalis.Result;
using MediatR;
using System.Text.Json.Serialization;

namespace Fsm.Application.Features.Users.UpdatePassword;

public record UpdatePasswordRequest : IRequest<Result>
{
    [JsonIgnore]
    public Guid Id { get; init; }
    
    public string Password { get; init; } = null!;
}