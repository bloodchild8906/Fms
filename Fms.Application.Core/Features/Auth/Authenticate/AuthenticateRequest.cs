using Ardalis.Result;
using MediatR;

namespace Fms.Application.Core.Features.Auth.Authenticate;

public sealed record AuthenticateRequest(string Username, string Password) : IRequest<Result<Jwt>>;