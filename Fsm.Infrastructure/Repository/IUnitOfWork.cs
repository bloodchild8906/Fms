using System.Threading.Tasks;

namespace Fsm.Infrastructure.Repository;

public interface IUnitOfWork
{
    Task CommitAsync();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
}