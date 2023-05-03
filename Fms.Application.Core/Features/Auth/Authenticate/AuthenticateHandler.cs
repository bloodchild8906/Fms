using Ardalis.Result;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fms.Application.Core.Common;
using Fms.Domain.DbEntity.Entities;
using Microsoft.Extensions.Logging;
using BC = BCrypt.Net.BCrypt;


namespace Fms.Application.Core.Features.Auth.Authenticate;

public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, Result<Jwt>>
{
    private readonly IContext _context;

    private readonly TokenConfiguration _appSettings;
    private ILogger<AuthenticateHandler> _logger;

    public AuthenticateHandler(IOptions<TokenConfiguration> appSettings, IContext context, ILogger<AuthenticateHandler> logger)
    {
        _context = context;
        this._logger = logger;
        _appSettings = appSettings.Value;
        
    }

    public async Task<Result<Jwt>> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Token Request started");
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Username.ToLower() == request.Username.ToLower(),
            cancellationToken);
        if (user == null || !BC.Verify(request.Password, user.Password))
        {
            return Result.Invalid(new List<ValidationError>
            {
                new()
                {
                    Identifier = $"{nameof(request.Password)}|{nameof(request.Username)}",
                    ErrorMessage = "Username or password is incorrect"
                }
            });
        }

        var role = await _context.Roles.FirstOrDefaultAsync(roles => roles.RoleId == user.RoleNavigator, cancellationToken: cancellationToken);
        user.RoleDetail = role??throw new Exception("Could not find the role referenced by the user");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var claims = new ClaimsIdentity(new Claim[]
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Username),
            new(ClaimTypes.Role, user.RoleDetail.Name!)
        });

        var expDate = DateTime.UtcNow.AddHours(1);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claims,
            Expires = expDate,
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Audience = _appSettings.Audience,
            Issuer = _appSettings.Issuer
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new Result<Jwt>(new Jwt(tokenHandler.WriteToken(token),expDate));
    }
}