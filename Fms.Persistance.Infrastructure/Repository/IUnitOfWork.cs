using System.Threading.Tasks;

namespace Fms.Persistance.Infrastructure.Repository;

public interface IUnitOfWork
{
    Task CommitAsync();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}