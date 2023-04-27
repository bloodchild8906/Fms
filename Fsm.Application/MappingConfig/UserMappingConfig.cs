using System;
using System.Diagnostics;
using Fsm.Application.Features.Users;
using Fsm.Application.Features.Users.CreateUser;
using Fsm.Domain.Auth;
using Fsm.Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Application.MappingConfig;

public class UserMappingConfig : IMappingConfig
{
    public void ApplyConfig()
    {
        
            TypeAdapterConfig<CreateUserRequest, User>
                .ForType()
                .Map(dest =>dest.Role1.Name,
                    opt => opt.IsAdmin ? Roles.Admin : Roles.User);

            TypeAdapterConfig<User, GetUserResponse>
                .ForType()
                .Map(dest => dest.IsAdmin,
                    x => x.Role1.Name == Roles.Admin);
    }
}