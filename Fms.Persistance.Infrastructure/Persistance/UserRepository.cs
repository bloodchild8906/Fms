using Fms.Domain.DbEntity.Entities;
using Fms.Persistance.Infrastructure.Repository;

namespace Fms.Persistance.Infrastructure.Persistance;

public class UserRepository : Repository<User>
{
    private readonly IUnitOfWork _unitOfWork;

    public UserRepository(IUnitOfWork unitOfWork) : base()
    {
        _unitOfWork = unitOfWork;
    }

}