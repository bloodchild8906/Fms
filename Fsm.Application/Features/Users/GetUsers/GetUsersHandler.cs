using Fsm.Application.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Fsm.Application.Common;
using Fsm.Application.Common.Responses;
using Fsm.Domain.Auth;

namespace Fsm.Application.Features.Users.GetUsers;

public class GetUsersHandler : IRequestHandler<GetUsersRequest, PaginatedList<GetUserResponse>>
{
    private readonly IContext _context;
    
    public GetUsersHandler(IContext context)
    {
        _context = context;
    }

    public async Task<PaginatedList<GetUserResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        var users = _context.Users
            .WhereIf(!string.IsNullOrEmpty(request.Username), x => EF.Functions.Like(x.Username, $"%{request.Username}%"))
            .WhereIf(request.IsAdmin, x => x.Role1.Name == Roles.Admin);
        return await users.ProjectToType<GetUserResponse>().ToPaginatedListAsync(request.CurrentPage, request.PageSize);
    }
}