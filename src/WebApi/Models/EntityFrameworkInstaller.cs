using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models;


    public static class EntityFrameworkInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
                    string connectionString)
        {
            services.AddDbContext<CustomerContext>(optionsBuilder
                => optionsBuilder.UseNpgsql(connectionString));

            return services;
        }

    }

