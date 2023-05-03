using FluentValidation;

namespace Fms.Application.Core.Features.Auth.JwtRefreshToken;

public class JwtRefreshTokenValidator : AbstractValidator<JwtRefreshRequest>
{

    public JwtRefreshTokenValidator()
    {
        ClassLevelCascadeMode = CascadeMode.Stop;
        RuleFor(x => x.Token)
            .NotEmpty();

        RuleFor(x => x.Token)
            .NotEmpty();
    }
}