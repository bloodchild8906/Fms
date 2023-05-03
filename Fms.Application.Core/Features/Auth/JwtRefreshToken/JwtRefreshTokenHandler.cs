using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Fms.Application.Core.Common;
using Fms.Application.Core.Features.Auth.Authenticate;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static System.Text.Encoding;


namespace Fms.Application.Core.Features.Auth.JwtRefreshToken;

public class JwtRefreshTokenHandler : IRequestHandler<JwtRefreshRequest, Result<Jwt>>
{
    private readonly IContext _context;

    private readonly IOptions<TokenConfiguration> _appSettings;

    public JwtRefreshTokenHandler(IOptions<TokenConfiguration> appSettings, IContext context)
    {
        _context = context;
        _appSettings = appSettings;
    }

    public Task<Result<Jwt>> Handle(JwtRefreshRequest request, CancellationToken cancellationToken)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var requestToken = tokenHandler.ReadToken(request.Token);
        if (DateTime.Compare(DateTime.Now, requestToken.ValidTo) < 0)
        {
            var claims = TokenValidator.ValidateToken(request.Token, _appSettings);
            var expDate = DateTime.UtcNow.AddHours(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = expDate,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(ASCII.GetBytes(_appSettings.Value.Secret)), 
                    SecurityAlgorithms.HmacSha256Signature
                    ),
                Audience = _appSettings.Value.Audience,
                Issuer = _appSettings.Value.Issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Task.FromResult<Result<Jwt>>(new Jwt(tokenHandler.WriteToken(token), expDate));
        }
        throw new SecurityException("the token supplied was incorrect");
    }
}
