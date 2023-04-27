using Ardalis.Result;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Net;
using Ardalis.Result.AspNetCore;
using Fms.Api.Common;
using Fms.Api.Configurations;

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

builder.Services.AddAuthSetup(builder.Configuration);

builder.Services.AddSwaggerSetup();

builder.Services.AddPersistenceSetup(builder.Configuration);

builder.Services.AddApplicationSetup();

builder.Services.AddCompressionSetup();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMediatRSetup();

builder.Services.AddScoped<ExceptionHandlerMiddleware>();

builder.Logging.ClearProviders();

if (builder.Environment.EnvironmentName != "Testing")
{
    builder.Host.UseLoggingSetup(builder.Configuration);
}

var app = builder.Build();

app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();
app.UseMiddleware(typeof(ExceptionHandlerMiddleware));

app.UseSwaggerSetup();

app.UseResponseCompression();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers()
   .RequireAuthorization();

await app.Migrate();

await app.RunAsync();