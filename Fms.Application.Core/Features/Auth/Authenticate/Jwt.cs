using System;
using Ardalis.Result;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Fms.Application.Core.Features.Auth.Authenticate;

public sealed record Jwt(string Token, DateTime ExpDate);
