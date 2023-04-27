using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Repository;

public class Provider : IProvider
{
    public DbContext CurrentDbContext { get; set; }
    protected Dictionary<Type, object> Repositories { get; private set; }

    public Provider(DbContext currentDbContext)
    {
        this.CurrentDbContext = currentDbContext;
        Repositories = new Dictionary<Type, object>();
    }

    public IRepository<TEntity> Repo<TEntity>() where TEntity : class
    {
        Repositories.TryGetValue(typeof(IRepository<TEntity>), out var repoOut);
        if (repoOut is not IRepository<TEntity> repo)
        {
            IRepository<TEntity> obj = new Repository<TEntity>(CurrentDbContext);
            Repositories[typeof(IRepository<TEntity>)] = obj;
            repo = obj;
        }
        return repo;
    }
}