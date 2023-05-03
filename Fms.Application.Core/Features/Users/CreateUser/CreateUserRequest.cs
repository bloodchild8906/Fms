
using Ardalis.Result;
using Fms.Application.Core.CustomTypes;
using Fms.Domain.DbEntity.Entities;
using MediatR;

namespace Fms.Application.Core.Features.Users.CreateUser;

public sealed record CreateUserRequest : IRequest<Result<GetUserResponse>>
{

    public string Username { get; set; }

    public string Password { get; set; }

   // public GeneralDetails PersonalDetails { get; set; }

    // public EmploymentDetails EmploymentDetails { get; set; }

    public Role RoleDetail { get; set; }

    // public UserType UserType { get; set; }

    
}