using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fsm.Domain.Entities;
using Fsm.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Infrastructure.Persistance;

public class UserRepository : Repository<User>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserRepository(IUnitOfWork unitOfWork) : base()
    {
        _unitOfWork = unitOfWork;
    }

}