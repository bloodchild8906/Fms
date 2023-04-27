using Microsoft.EntityFrameworkCore;

namespace Fsm.Infrastructure.Repository;

public interface IProvider
{
    DbContext CurrentDbContext { get; set; }

    IRepository<TEntity> Repo<TEntity>() where TEntity : class;
}