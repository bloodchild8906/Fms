using Fms.Domain.DbEntity.Entities;
using Fms.Persistance.Infrastructure.Repository;

namespace Fms.Persistance.Infrastructure.Persistance;

public class RoleRepository : Repository<Role>
{
    private readonly IUnitOfWork _unitOfWork;

    public RoleRepository(IUnitOfWork unitOfWork) : base()
    {
        _unitOfWork = unitOfWork;
    }

}