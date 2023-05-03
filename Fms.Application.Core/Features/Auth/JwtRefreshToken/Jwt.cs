using Ardalis.Result;
using Fms.Application.Core.Features.Auth.Authenticate;
using MediatR;

namespace Fms.Application.Core.Features.Auth.JwtRefreshToken;

public record JwtRefreshRequest(string Token) : IRequest, IRequest<Result<Jwt>>;