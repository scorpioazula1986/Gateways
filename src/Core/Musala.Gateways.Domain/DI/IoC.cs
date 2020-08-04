

using Microsoft.Extensions.DependencyInjection;
using Musala.Gateways.Domain.Orchestrators;

namespace Musala.Gateways.Domain
{
    public static class IoCDomain
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddScoped<IGatewayOrchestrator, GatewayOrchestrator>();
            services.AddScoped<IDeviceOrchestrator, DeviceOrchestrator>();
            return services;


        }
        
    }
}