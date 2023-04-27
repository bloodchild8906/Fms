using Fms.Application.Core.Common.Requests;
using Fms.Application.Core.Common.Responses;
using MediatR;

namespace Fms.Application.Core.Features.Users.GetUsers;

public record GetUsersRequest : PaginatedRequest, IRequest<PaginatedList<GetUserResponse>>
{
    public string? Username { get; init; }
    public bool IsAdmin { get; init; }
}