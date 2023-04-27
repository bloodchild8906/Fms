﻿using System;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Fsm.Application.Common.Responses;
using Fsm.Application.Features.Auth.Authenticate;
using Fsm.Application.Features.Users;
using Fsm.Application.Features.Users.CreateUser;
using Fsm.Application.Features.Users.DeleteUser;
using Fsm.Application.Features.Users.GetUserById;
using Fsm.Application.Features.Users.GetUsers;
using Fsm.Application.Features.Users.UpdatePassword;
using Fsm.Domain.Auth;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fms.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserController : ControllerBase
{
    private readonly Fsm.Domain.Auth.Interfaces.ISession _session;
    private readonly IMediator _mediator;

    public UserController(Fsm.Domain.Auth.Interfaces.ISession session, IMediator mediator)
    {
        _session = session;
        _mediator = mediator;
    }

    /// <summary>
    /// Authenticates the user and returns the token information.
    /// </summary>
    /// <param name="request">Email and password information</param>
    /// <returns>Token information</returns>
    [HttpPost]
    [Route("authenticate")]
    [AllowAnonymous]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid)]
    public async Task<Result<Jwt>> Authenticate([FromBody] AuthenticateRequest request)
    {
        var jwt = await _mediator.Send(request);
        return jwt;
    }


    /// <summary>
    /// Returns all users in the database
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [ProducesResponseType(typeof(PaginatedList<GetUserResponse>), StatusCodes.Status200OK)]
    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    public async Task<ActionResult<PaginatedList<GetUserResponse>>> GetUsers([FromQuery] GetUsersRequest request)
    {
        return Ok(await _mediator.Send(request));
    }


    /// <summary>
    /// Get one user by id from the database
    /// </summary>
    /// <param name="id">The user's ID</param>
    /// <returns></returns>
    [Authorize(Roles = Roles.Admin)]
    [HttpGet]
    [Route("{id}")]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.NotFound)]
    public async Task<Result<GetUserResponse>> GetUserById(Guid id)
    {
        var result = await _mediator.Send(new GetUserByIdRequest(id));
        return result;
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpPost]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.Invalid)]
    public async Task<Result<GetUserResponse>> CreateUser(CreateUserRequest request)
    {
        var result = await _mediator.Send(request);
        return result;
    }

    [HttpPatch("password")]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.NotFound, ResultStatus.Invalid)]
    public async Task<Result> UpdatePassword([FromBody] UpdatePasswordRequest request)
    {            
        var result = await _mediator.Send(request with { Id = _session.Id });
        return result;
    }

    [Authorize(Roles = Roles.Admin)]
    [HttpDelete("{id}")]
    [TranslateResultToActionResult]
    [ExpectedFailures(ResultStatus.NotFound, ResultStatus.Invalid)]
    public async Task<Result> DeleteUser(Guid id)
    {
        var result = await _mediator.Send(new DeleteUserRequest(id));
        return result;
    }
}