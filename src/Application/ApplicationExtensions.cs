using System.Collections.Generic;
using Application.Flows.Locations.Queries;
using Application.Models;
using Application.Request;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddMemoryCache()
                //
                // .AddTransient<IRequestHandler<CreateTokenCommand, TokenObjectModel>, CreateTokenHandler>().AddTransient<IValidator<CreateTokenCommand>, CreateTokenValidator>()
                //
                .AddTransient<IRequestHandler<FilterLocationsCommand, ICollection<LocationObjectModel>>, FilterLocationsHandler>().AddTransient<IValidator<FilterLocationsCommand>, FilterLocationsValidator>()
                //
                ;

            return services;
        }
    }
}