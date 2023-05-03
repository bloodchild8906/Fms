using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static System.Text.Encoding;
using static Microsoft.IdentityModel.Logging.IdentityModelEventSource;

namespace Fms.Application.Core.Common;

public class TokenValidator
{
    public static ClaimsIdentity ValidateToken(string jwtToken, IOptions<TokenConfiguration> appSettings)
    {
        ShowPII = true;
        var validationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidAudience = appSettings.Value.Audience,
            ValidIssuer = appSettings.Value.Issuer,
            IssuerSigningKey = new SymmetricSecurityKey(UTF8.GetBytes(appSettings.Value.Secret))
        };
        var principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out _);
        return new ClaimsIdentity(principal.Claims);
    }
}