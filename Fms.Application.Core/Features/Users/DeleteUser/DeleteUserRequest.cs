using System;
using Ardalis.Result;
using MediatR;

namespace Fms.Application.Core.Features.Users.DeleteUser;

public record DeleteUserRequest(Guid Id) : IRequest<Result>;