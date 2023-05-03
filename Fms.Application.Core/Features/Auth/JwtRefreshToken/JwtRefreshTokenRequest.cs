using Ardalis.Result;
using Fms.Application.Core.Features.Auth.Authenticate;
using MediatR;

namespace Fms.Application.Core.Features.Auth.JwtRefreshToken;

public record JwtRefreshTokenRequest(string Token) : IRequest<Result<Jwt>>;