using System;
using Ardalis.Result;
using MediatR;

namespace Fsm.Application.Features.Users.GetUserById;

public record GetUserByIdRequest(Guid Id) : IRequest<Result<GetUserResponse>>;