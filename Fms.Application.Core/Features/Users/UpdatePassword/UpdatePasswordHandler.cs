using Ardalis.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Fms.Application.Core.Common;
using BC = BCrypt.Net.BCrypt;

namespace Fms.Application.Core.Features.Users.UpdatePassword;

public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordRequest, Result>
{
    private readonly IContext _context;

    public UpdatePasswordHandler(IContext context)
    {
        _context = context;
    }


    public async Task<Result> Handle(UpdatePasswordRequest request, CancellationToken cancellationToken)
    {
        var originalUser = await _context.Users
            .FirstAsync(x => x.Id == request.Id, cancellationToken);
        originalUser.Password = BC.HashPassword(request.Password);
        _context.Users.Update(originalUser);
        await _context.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}