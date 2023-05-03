using System.Threading;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Fms.Application.Core.Features.Auth.Authenticate;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fms.Integrations.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly Fms.Domain.DbEntity.Auth.Interfaces.ISession _session;
    private readonly IMediator _mediator;

    public AuthController(Fms.Domain.DbEntity.Auth.Interfaces.ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    /// <summary>
    /// Authenticates a user and returns the token information.
    /// __please note!__ that the password is a *md5* hash will not succeed if you do not encode it before sending
    /// </summary>
    /// <param name="request">username and password information</param>
    /// <returns><see cref="Jwt"/> jwt</returns>
    [
        HttpPost,
        AllowAnonymous,
        TranslateResultToActionResult,
        ApiExplorerSettings,
        ExpectedFailures(ResultStatus.Invalid), 
    ]
    public async Task<Result<Jwt>> Authenticate([FromBody] AuthenticateRequest request)
    {
        var jwt = await _mediator.Send(request);
        return jwt;
    }
    /// <summary>
    /// Refreshes a token if it is valid
    /// </summary>
    /// <param name="request">the taken before it has expired</param>
    /// <returns><see cref="Jwt"/>Jwt</returns>
    [
        HttpPatch,
        AllowAnonymous,
        TranslateResultToActionResult,
        ExpectedFailures(ResultStatus.Invalid)
    ]
    public async Task<Result<Jwt>> Authenticate([FromBody] Jwt request)
    {
        var jwt = await _mediator.Send(request);
        return null;
    }
}
