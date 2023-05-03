using System.Collections.Generic;

namespace Fms.Persistance.Infrastructure.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    void Add(TEntity entity);
    List<TEntity> GetAll();
    void Remove(TEntity entity);
    void Update(TEntity entity);
}