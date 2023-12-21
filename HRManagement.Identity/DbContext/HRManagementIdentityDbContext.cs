using HReManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRManagement.Identity.DbContext;


    public class HRManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HRManagementIdentityDbContext(DbContextOptions<HRManagementIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HRManagementIdentityDbContext).Assembly);
        }
    }
