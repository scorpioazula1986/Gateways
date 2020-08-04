using Microsoft.AspNetCore.Builder;
using Musala.Gateways.Core.Middlewares;

namespace Musala.Gateways.Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
        
    }
}