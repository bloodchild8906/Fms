using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Fms.Api.Configurations;

public static class ValidationSetup
{
    public static void AddValidationSetup(this IMvcBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblyContaining<Fsm.Application.IAssemblyMarker>();
    }
}
