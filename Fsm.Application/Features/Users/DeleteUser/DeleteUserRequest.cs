using System;
using Ardalis.Result;
using MediatR;

namespace Fsm.Application.Features.Users.DeleteUser;

public record DeleteUserRequest(Guid Id) : IRequest<Result>;