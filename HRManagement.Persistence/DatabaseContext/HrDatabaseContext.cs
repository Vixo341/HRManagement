using HRManagement.Application.Contracts.Identity;
using HRManagement.Domain;
using HRManagement.Domain.Common;
using HRManagement.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Persistence.DatabaseContext;

public class HrDatabaseContext : DbContext
{
    private readonly IUserService _userService;
    public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options, IUserService userService) : base(options)
    {
        _userService = userService;
    }

    public DbSet<LeaveType> LeaveTypes { get; set; }
    public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
        
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach(var entry in ChangeTracker.Entries<BaseEntity>().Where(q=> q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.DateModified = DateTime.Now;
                    entry.Entity.CreatedBy = _userService.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.DateModified = DateTime.Now;
                    entry.Entity.ModifiedBy = _userService.UserId;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}