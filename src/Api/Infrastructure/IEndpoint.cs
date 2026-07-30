namespace Api.Infrastructure;

public interface IEndpoint
{
    void MapEndpoints(IEndpointRouteBuilder routes);
}
