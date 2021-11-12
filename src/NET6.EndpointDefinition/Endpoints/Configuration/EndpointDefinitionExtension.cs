namespace NET6.EndpointDefinition.Endpoints.Configuration;

public static class EndpointDefinitionExtension
{
    public static void AddEndpointDefinitions(this IServiceCollection services, params Type[] types)
    {
        var endpoints = new List<IEndpointDefinition>();

        foreach (var type in types)
        {
            endpoints.AddRange(
                type.Assembly.ExportedTypes
                    .Where(x => typeof(IEndpointDefinition).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(Activator.CreateInstance).Cast<IEndpointDefinition>()
            );
        }

        foreach (var endpoint in endpoints)
        {
            endpoint.DefineServices(services);
        }

        services.AddSingleton(endpoints as IReadOnlyCollection<IEndpointDefinition>);
    }

    public static void UseEndpointDefinitions(this WebApplication app)
    {
        var definitions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();

        foreach (var definition in definitions)
        {
            definition.DefineEndpoints(app);
        }
    }
}

