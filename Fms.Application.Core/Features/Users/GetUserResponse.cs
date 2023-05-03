using System;
using Fms.Domain.DbEntity.Entities;

namespace Fms.Application.Core.Features.Users;

public record GetUserResponse(Guid Id,string Username,Role RoleDetail );