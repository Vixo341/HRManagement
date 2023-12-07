using HRManagement.Application.Contracts.Email;
using HRManagement.Application.Contracts.Logging;
using HRManagement.Application.Models.Email;
using HRManagement.Infrastructure.EmailService;
using HRManagement.Infrastructure.LoggingService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRManagement.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        return services;
    }
}