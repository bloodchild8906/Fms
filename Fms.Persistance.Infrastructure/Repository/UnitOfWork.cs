using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Fms.Persistance.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly DbContext _dbContext;
    private readonly IProvider _provider;
    public UnitOfWork(IProvider provider)
    {
        _provider = provider;
        provider.CurrentDbContext = _dbContext;
           
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        return  _provider.Repo<TEntity>();
    }

    public Task CommitAsync()
    {
        if (_dbContext is null)
        {
            throw new ArgumentNullException($"{nameof(_dbContext)} Context is null");
        }
        return _dbContext.SaveChangesAsync();
    }

}