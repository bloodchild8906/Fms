﻿using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using Ardalis.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Fms.Integrations.Api.Common;

public sealed class ExceptionHandlerMiddleware : IMiddleware
{
    private readonly ILogger<ExceptionHandlerMiddleware> _logger;

    public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var exception = ex.Demystify();
            _logger.LogError(exception, "An error ocurred: {Message}", exception.Message);
            var code = exception switch
            {
                _ => HttpStatusCode.InternalServerError
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            var result = Result.Error(exception.ToStringDemystified());
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}