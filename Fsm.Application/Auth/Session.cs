using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Fsm.Application.Auth;

public class Session : Domain.Auth.Interfaces.ISession
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