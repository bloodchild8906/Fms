using System;
using System.Collections.Immutable;
using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using Fms.Domain.DbEntity.Entities;
using Fms.Integrations.Api.AuthHandlers;
using Fms.Integrations.Api.Common;
using Fms.Integrations.Api.Configurations;
using Fms.Integrations.Api.Controllers;
using Fms.Integrations.Api.Providers;
using Fms.Persistance.Infrastructure.Context;
using Fms.Persistance.Infrastructure.Persistance;
using Fms.Persistance.Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers(options =>
    {
        options.AllowEmptyInputInBodyModelBinding = true;
        options.AddResultConvention(resultMap =>
        {
            resultMap.AddDefaultMap()
                .For(ResultStatus.Ok, HttpStatusCode.OK, resultStatusOptions => resultStatusOptions
                    .For("POST", HttpStatusCode.Created)
                    .For("DELETE", HttpStatusCode.NoContent));
        });
    })
    .AddValidationSetup();
builder.Services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
builder.Services.AddSingleton<IAuthorizationHandler, CustomAuthorizationHandler>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddAuthSetup(builder.Configuration);
builder.Services.AddSwaggerSetup();
builder.Services.AddPersistenceSetup(builder.Configuration);
builder.Services.AddApplicationSetup();
builder.Services.AddCompressionSetup();
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatRSetup();
builder.Services.AddScoped<ExceptionHandlerMiddleware>();
builder.Logging.ClearProviders();
builder.Host.UseLoggingSetup(builder.Configuration);
builder.Services.AddSignalR();


var app = builder.Build();
app.UseStaticFiles();

app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
app.UseSwaggerSetup();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseResponseCompression();
app.UseHttpsRedirection();

//FOR SIGNALR

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
    .RequireAuthorization();
try
{
    await app.Migrate(false);
}
catch (Exception)
{
    //ignore
}

await app.RunAsync();