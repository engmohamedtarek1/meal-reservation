using Core.Interfaces.Services;
using Service;

namespace API.ServicesExtension
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register AuthService
            services.AddScoped(typeof(IAuthService), typeof(AuthService));

            return services;
        }
    }
}