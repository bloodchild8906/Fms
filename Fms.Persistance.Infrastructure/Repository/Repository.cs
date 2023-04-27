using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext DbContext = null!;

    public Repository(DbContext dbContext) => DbContext = dbContext;

    protected Repository() => Expression.Empty();

    public List<TEntity> GetAll() => DbContext.Set<TEntity>().ToList();

    // ReSharper disable once MethodNameNotMeaningful
    public virtual void Add(TEntity entity) =>DbContext.Add(entity);

    public virtual void Update(TEntity entity) => DbContext.Update(entity);

    public virtual void Remove(TEntity entity) => DbContext.Remove(entity);
}