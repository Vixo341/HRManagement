using System.Runtime.Serialization;
using Microsoft.Extensions.DependencyInjection;

namespace HRManagement.Persistence;

public static class PersistenceServiceRegistration
{

    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        return services;
    }
    
}