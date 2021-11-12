namespace NET6.EndpointDefinition.Endpoints.Configuration;
public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);

    void DefineEndpoints(WebApplication app);
}

