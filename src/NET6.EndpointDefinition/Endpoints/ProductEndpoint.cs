using NET6.EndpointDefinition.Endpoints.Configuration;
using NET6.EndpointDefinition.Models;

namespace NET6.EndpointDefinition.Endpoints
{
    public class ProductEndpoint : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("/products", () => "Products List");
            app.MapGet("/products/{id}", (Guid id) => $"Product Id: {id}");
            app.MapPost("/products", (Product product) => Results.Ok(product));
            app.MapPut("/products/{id}", (Guid id, Product product) => Results.Ok(product));
            app.MapDelete("/products/{id}", (Guid id) => $"Delete Product: {id}");
        }

        public void DefineServices(IServiceCollection services)
        {
            // Define your services here
        }
    }
}
