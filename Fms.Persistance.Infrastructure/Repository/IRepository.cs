using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fms.Persistance.Infrastructure.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    List<TEntity> GetAll();
    void Remove(TEntity entity);
    void Update(TEntity entity);
}