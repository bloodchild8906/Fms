using Fms.Domain.DbEntity.Entities;
using Mapster;
using Microsoft.SqlServer.Server;

public class MapsterConfig : ICodeGenerationRegister
{
    public void Register(CodeGenerationConfig config)
    {
        config.AdaptTo("[name]Dto")
            .ForType<User>(
                cfg =>
                {
                    cfg.Ignore(User => User.Password);
                    cfg.Map(User => User.Username, "Username");
                    cfg.Map(User => User.Role1, "Role");
                    cfg.Map(User => User.UserType, typeof(UserType), "UserType");

                });
    }
}