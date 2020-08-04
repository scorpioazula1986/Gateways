
using Microsoft.Extensions.DependencyInjection;
using Musala.Gateways.Domain.Services.Interfaces;

namespace Musala.Gateways.Persistence.Services
{
    public static class IoCPersistence
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IGatewayService, GatewayService>();
            services.AddScoped<IDeviceService, DeviceService>();
            return services;


        }
        
    }
}