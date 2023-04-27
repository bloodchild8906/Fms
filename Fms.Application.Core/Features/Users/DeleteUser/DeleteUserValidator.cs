using FluentValidation;

namespace Fms.Application.Core.Features.Users.DeleteUser;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x).NotEmpty();
    }
    
}