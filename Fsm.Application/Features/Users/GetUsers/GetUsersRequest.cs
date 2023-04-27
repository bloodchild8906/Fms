using Fsm.Application.Common.Requests;
using Fsm.Application.Common.Responses;
using MediatR;

namespace Fsm.Application.Features.Users.GetUsers;

public record GetUsersRequest : PaginatedRequest, IRequest<PaginatedList<GetUserResponse>>
{
    public string? Username { get; init; }
    public bool IsAdmin { get; init; }
}