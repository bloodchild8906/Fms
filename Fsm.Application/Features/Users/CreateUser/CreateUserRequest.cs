using Ardalis.Result;
using MediatR;

namespace Fsm.Application.Features.Users.CreateUser;

public record CreateUserRequest : IRequest<Result<GetUserResponse>>
{
    public string Username { get; init; } = null!;

    public string Password { get; init; } = null!;

    public bool IsAdmin { get; init; }
}