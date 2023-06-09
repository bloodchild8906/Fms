﻿using Ardalis.Result;
using Mapster;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Fms.Application.Core.Common;
using Fms.Domain.DbEntity.Entities;
using BC = BCrypt.Net.BCrypt;

namespace Fms.Application.Core.Features.Users.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, Result<GetUserResponse>>
{
    private readonly IContext _context;
    
    
    public CreateUserHandler( IContext context)
    {
        _context = context;
    }
    public async Task<Result<GetUserResponse>> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var created = request.Adapt<User>();
        _context.Users.Add(created);
        created.Password = BC.HashPassword(request.Password);
        await _context.SaveChangesAsync(cancellationToken);
        return created.Adapt<GetUserResponse>();
    }
}