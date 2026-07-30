using Api.Infrastructure;

namespace Api.Endpoints;

/// <summary>
/// 追加例：items 取得（DBアクセスなし）
/// </summary>
public sealed class SampleItemsEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routes)
    {
        routes.MapGet("/items/{id:int}", (int id) =>
        {
            return Results.Ok(new { id, name = $"item-{id}" });
        })
        .WithName("GetItem");
    }
}
