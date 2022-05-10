using Microsoft.Extensions.DependencyInjection;
using Application.Services.GenericRepo;

namespace Application
{
    public static class AddServices
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IDapper, Dapperr>();
           
            return services;
        }
    }
}
