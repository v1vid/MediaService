using Itmo.Dev.Platform.Postgres.Extensions;
using Itmo.Dev.Platform.Postgres.Plugins;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.Abstractions.Persistence;
using Sample.Infrastructure.Sample.Infrastructure.Persistence.Contexts;
namespace Sample.Infrastructure.Sample.Infrastructure.Persistence.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection)
    {
        collection.AddPlatformPostgres(builder => builder.BindConfiguration("Infrastructure:Persistence:Postgres"));

        collection.AddPlatformMigrations(typeof(IAssemblyMarker).Assembly);

        // TODO: add repositories
        collection.AddScoped<IPersistenceContext, PersistenceContext>();


        return collection;
    }

    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetSection("Infrastructure:Persistence:Postgres:ConnectionString").Value));
        return collection;
    }
}