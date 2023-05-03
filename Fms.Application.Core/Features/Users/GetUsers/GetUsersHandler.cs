using Fms.Application.Core.Extensions;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Fms.Application.Core.Common;
using Fms.Application.Core.Common.Responses;
using Fms.Domain.DbEntity.Auth;

namespace Fms.Application.Core.Features.Users.GetUsers;

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
            .WhereIf(condition: !string.IsNullOrEmpty(request.Username), x => EF.Functions.Like(x.Username, $"%{request.Username}%"))
            .WhereIf(condition: request.IsAdmin, x => "x.Role.Name" == Roles.Admin);
        return await users.ProjectToType<GetUserResponse>().ToPaginatedListAsync(request.CurrentPage, request.PageSize);
    }
}