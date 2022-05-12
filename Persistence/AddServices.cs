using Microsoft.Extensions.DependencyInjection;
using Persistence.Interfaces;
using Persistence.Interfaces.GenericRepo;
using Persistence.Services;



namespace Persistence
{
    public static class AddServices
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ICrudDapper, CrudDapper>();
            services.AddScoped<IExcerciseService, ExcerciseService>();
            return services;
        }
    }
}
