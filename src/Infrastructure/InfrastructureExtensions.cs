using Application;
using Application.Persistence;
using Application.Services;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureExtensions
    {
        public static IServiceCollection AddInfrastucture(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddApplication(configuration)
                //
                .AddDbContext<InMemoryDataContext>(options => options.UseInMemoryDatabase(databaseName: "InMemoryDatabase"))
                .AddScoped<IDataContext>(provider => provider.GetService<InMemoryDataContext>())
                //
                .AddScoped<IEventDispatcherService, EventDispatcherService>()
                ;

            return services;
        }
    }
}