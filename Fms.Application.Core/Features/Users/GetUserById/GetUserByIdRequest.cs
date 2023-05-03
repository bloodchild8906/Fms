using System;
using Ardalis.Result;
using MediatR;

namespace Fms.Application.Core.Features.Users.GetUserById;

public sealed record GetUserByIdRequest(Guid Id) : IRequest<Result<GetUserResponse>>;