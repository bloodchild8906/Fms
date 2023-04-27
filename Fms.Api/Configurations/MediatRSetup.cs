using Fms.Application.Core.Common.Behaviors;
using Microsoft.Extensions.DependencyInjection;

namespace Fms.Api.Configurations;

public static class MediatRSetup
{
    public static IServiceCollection AddMediatRSetup(this IServiceCollection services)
    {
        services.AddMediatR((config) =>
        {
            config.RegisterServicesFromAssemblyContaining(typeof(Fms.Application.Core.IAssemblyMarker));
            config.AddOpenBehavior(typeof(ValidationResultPipelineBehavior<,>));
        });
        


        return services;
    }
}