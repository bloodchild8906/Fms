using FluentValidation;

namespace Fsm.Application.Features.Users.DeleteUser;

public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x).NotEmpty();
    }
    
}