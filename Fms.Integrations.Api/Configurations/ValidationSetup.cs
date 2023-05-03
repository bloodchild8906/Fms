using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Fms.Integrations.Api.Configurations;

public static class ValidationSetup
{
    public static void AddValidationSetup(this IMvcBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<Fms.Application.Core.IAssemblyMarker>();
    }
}
