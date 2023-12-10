using System.Runtime.Serialization;
using HRManagement.Application.Contracts.Persistence;
using HRManagement.Domain;
using HRManagement.Persistence.DatabaseContext;
using HRManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRManagement.Persistence;

public static class PersistenceServiceRegistration
{

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HrDatabaseContext>(options =>
        { 
            options.UseSqlServer(
                configuration.GetConnectionString("HRManagementConnectionString"), 
                b => b.MigrationsAssembly("HRManagement.Persistence"));
        });

      //  dotnet ef migrations add FirstMigration --assembly HRManagement.Persistence

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository,LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        
        return services;
    }
    
}