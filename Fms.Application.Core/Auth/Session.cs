using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Fms.Application.Core.Auth;

public class Session : Domain.DbEntity.Auth.Interfaces.ISession
{
    public Guid Id { get; private init; }

    public DateTime Now => DateTime.Now;

    public Session(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        var nameIdentifier = user?.FindFirst(ClaimTypes.NameIdentifier);

        if(nameIdentifier != null)
        {
            Id = new Guid(nameIdentifier.Value);
        }
    }

}