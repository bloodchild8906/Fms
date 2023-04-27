using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fms.Domain.DbEntity.Entities;
using Fms.Persistance.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Persistance;

public class UserRepository : Repository<User>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserRepository(IUnitOfWork unitOfWork) : base()
    {
        _unitOfWork = unitOfWork;
    }

}