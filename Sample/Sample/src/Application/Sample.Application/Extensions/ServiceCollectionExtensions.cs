using Microsoft.Extensions.DependencyInjection;

namespace Sample.Application.Sample.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        return collection;
    }
}