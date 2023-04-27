using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Threading;
using System.Threading.Tasks;
using Fsm.Domain.Entities;

namespace Fsm.Application.Common;

public interface IContext : IAsyncDisposable, IDisposable
{
    public DatabaseFacade Database { get; }
    public DbSet<Activity> Activities { get; set; }

    public DbSet<ActivityLog> ActivityLogs { get; set; }

    public DbSet<CheckLists> CheckLists { get; set; }

    public DbSet<ContactDomainRoles> ContactDomainRoles { get; set; }

    public DbSet<Documents> Documents { get; set; }

    public DbSet<EmploymentDetails> EmploymentDetails { get; set; }

    public DbSet<GeneralDetails> GeneralDetails { get; set; }

    public DbSet<RoleGroup> RoleGroups { get; set; }

    public DbSet<RoleObject> RoleObjects { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Skills> Skills { get; set; }

    public DbSet<Ticket> Tickets { get; set; }

    public DbSet<User> Users { get; set; }
    
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}