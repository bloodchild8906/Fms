using Fsm.Application.Common;
using Fsm.Domain.Entities;
using Fsm.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Fsm.Infrastructure.Context;

public class ApplicationDbContext : DbContext, IContext
{
    protected ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ActivityLogMap());
        modelBuilder.ApplyConfiguration(new ActivityMap());
        modelBuilder.ApplyConfiguration(new CheckListsMap());
        modelBuilder.ApplyConfiguration(new ContactDomainRolesMap());
        modelBuilder.ApplyConfiguration(new DocumentsMap());
        modelBuilder.ApplyConfiguration(new EmploymentDetailsMap());
        modelBuilder.ApplyConfiguration(new GeneralDetailsMap());
        modelBuilder.ApplyConfiguration(new RoleGroupMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new RoleObjectMap());
        modelBuilder.ApplyConfiguration(new SkillsMap());
        modelBuilder.ApplyConfiguration(new TicketMap());
        modelBuilder.ApplyConfiguration(new UserMap());
    }
}