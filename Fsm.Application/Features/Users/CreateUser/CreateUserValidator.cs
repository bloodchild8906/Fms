using System;
using FluentValidation;
using Fsm.Application.Common;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Application.Features.Users.CreateUser;

public class CreateUserValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserValidator(IContext context)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(5)
            .MaximumLength(255);
        
        RuleFor(x => x.Username)
            .NotEmpty()
            .MaximumLength(254)
            .MustAsync(async (email, ct) => !await context.Users.AnyAsync(y => string.Equals(y.Username, email, StringComparison.CurrentCultureIgnoreCase), cancellationToken: ct))
            .WithMessage("A user with this username already exists.");

    }
}