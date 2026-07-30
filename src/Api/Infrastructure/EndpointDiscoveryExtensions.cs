using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure;

public static class EndpointDiscoveryExtensions
{
    public static IEndpointRouteBuilder MapDiscoveredEndpoints(
        this IEndpointRouteBuilder routes,
        IServiceProvider services,
        params Assembly[] assemblies)
    {
        if (assemblies is null || assemblies.Length == 0)
            assemblies = [Assembly.GetExecutingAssembly()];

        var endpointTypes = assemblies
            .SelectMany(a => a.DefinedTypes)
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .Where(t => typeof(IEndpoint).IsAssignableFrom(t))
            .Select(t => t.AsType())
            .Select(t => new
            {
                Type = t,
                Order = t.GetCustomAttribute<EndpointOrderAttribute>()?.Order ?? 0
            })
            .OrderBy(x => x.Order)
            .ThenBy(x => x.Type.FullName)
            .ToList();

        foreach (var item in endpointTypes)
        {
            var endpoint = (IEndpoint)ActivatorUtilities.CreateInstance(services, item.Type);
            endpoint.MapEndpoints(routes);
        }

        return routes;
    }
}
