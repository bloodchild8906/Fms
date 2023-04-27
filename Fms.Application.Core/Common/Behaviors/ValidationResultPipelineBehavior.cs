using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Fms.Application.Core.Common.Behaviors;

public class ValidationResultPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : notnull
{
    private readonly IServiceProvider _serviceProvider;

    public ValidationResultPipelineBehavior(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_serviceProvider.GetService<IValidator<TRequest>>() is { } validator)
        {
            var result = await validator.ValidateAsync(request, cancellationToken);
            if (!result.IsValid)
            {
                return (TResponse)(dynamic)Result.Invalid(result.AsErrors());
            }
        }
        
        return await next();
    }
}


