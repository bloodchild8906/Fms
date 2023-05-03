// using Fms.Application.Core.CustomTypes;
// using Fms.Domain.DbEntity.Entities;
// using Mapster;
//
// public class MapsterConfig : ICodeGenerationRegister
// {
//     public void Register(CodeGenerationConfig config)
//     {
//         config.AdaptTo("[name]Dto")
//             .ForType<User>(
//                 cfg =>
//                 {
//                     cfg.Ignore(User => User.Password);
//                     cfg.Map(User => User.Username, "Username");
//                     cfg.Map(User => User.Role, Role);
//                     //cfg.Map(User => User..UserType, typeof(UserType), "UserType");
//
//                 });
//     }
// }