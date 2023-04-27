using System;
using System.Diagnostics;
using Fms.Application.Core.Features.Users;
using Fms.Application.Core.Features.Users.CreateUser;
using Fms.Domain.DbEntity.Auth;
using Fms.Domain.DbEntity.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Fms.Application.Core.MappingConfig;

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