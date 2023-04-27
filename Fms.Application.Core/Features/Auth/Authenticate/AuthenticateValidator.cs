using FluentValidation;

namespace Fms.Application.Core.Features.Auth.Authenticate;

public class AuthenticateValidator : AbstractValidator<AuthenticateRequest>
{

    public AuthenticateValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Username)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();
    }
}