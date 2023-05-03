using System;
using System.Text;
using System.Threading.Tasks;
using Fms.Application.Core.Common;
using Fms.Application.Core.Features.Auth.Authenticate;
using Fms.Integrations.Api.AuthHandlers;
using Fms.Integrations.Api.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Fms.Integrations.Api.Configurations;

public static class AuthSetup
{
    public static IServiceCollection AddAuthSetup(this IServiceCollection services, IConfiguration configuration)
    {
        
        var tokenConfig = configuration.GetRequiredSection("TokenConfiguration");
        services.Configure<TokenConfiguration>(tokenConfig);

        var appSettings = tokenConfig.Get<TokenConfiguration>();
        var key = Encoding.ASCII.GetBytes(appSettings!.Secret);
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(x =>
        {
           // x.Events = JwtSignalRSetup.HandleAuthEvents();
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = appSettings.Issuer,
                ValidAudience = appSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
        });


        services.AddAuthorization(options =>
        {
            options.InvokeHandlersAfterFailure = false;
            options.AddPolicy("CustomHubAuthorizatioPolicy", policy =>  
            {  
                policy.Requirements.Add(new CustomAuthorizationRequirement());  
            });  
        });

        return services;
    }
}
//
// public static class JwtSignalRSetup
// {
//     public static JwtBearerEvents HandleAuthEvents()
//         => new()
//         {
//             OnMessageReceived = OnMessageReceived,
//             OnAuthenticationFailed = OnMessageTokenFail,
//             OnTokenValidated = OnTokenValidated,
//             OnChallenge = OnChallenge,
//             OnForbidden = OnForbidden
//         };
//
//     private static async Task OnForbidden(ForbiddenContext context)
//     {
//     }
//
//     private static async Task OnChallenge(JwtBearerChallengeContext context)
//     {
//     }
//
//     private static async Task OnTokenValidated(TokenValidatedContext context)
//     {
//     }
//
//     private static async Task OnMessageReceived(MessageReceivedContext context)
//     {
//         if (string.IsNullOrEmpty(context.Token))
//         {
//             if (context.Request.Path=="/hubs/FsmHub/Connect")
//             {
//                 var userRequest=JsonConvert.DeserializeObject<AuthenticateRequest>(context.Request.Body.)
//             }
//             var accessToken = context.Request.Path();
//             var path = context.HttpContext.Request.Path;
//                 
//             if (!string.IsNullOrEmpty(accessToken) && 
//                 path.StartsWithSegments("/hubs"))
//             {
//                 context.Token = accessToken;
//             }
//         }
//     }
//
//     private static async Task OnMessageTokenFail(AuthenticationFailedContext context)
//     {
//     }
//
// }