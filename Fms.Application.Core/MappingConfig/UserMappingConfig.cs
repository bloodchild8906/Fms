using Fms.Application.Core.Features.Users;
using Fms.Application.Core.Features.Users.CreateUser;
using Fms.Domain.DbEntity.Auth;
using Fms.Domain.DbEntity.Entities;
using Mapster;

namespace Fms.Application.Core.MappingConfig;

public class UserMappingConfig : IMappingConfig
{
    public void ApplyConfig()
    {
        
            TypeAdapterConfig<CreateUserRequest, User>
                .ForType()
                .Map(dest =>dest.RoleDetail.Name,
                    opt => opt.RoleDetail.Name);

            TypeAdapterConfig<User, GetUserResponse>
                .ForType()
                .Map(dest => dest.RoleDetail.Name,
                    x => x.RoleDetail.Name == Roles.Admin);
    }
}