using Api.Infrastructure;
using Microsoft.Data.SqlClient;

namespace Api.Endpoints;

[EndpointOrder(-1000)]
public sealed class HealthEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routes)
    {
        routes.MapGet("/health", () => Results.Ok(new { status = "ok" }))
              .WithName("Health");

        // DIで設定した "Management" の接続文字列を使って疎通確認（例）
        routes.MapGet("/health/db", async (IConfiguration config) =>
        {
            var cs = config.GetConnectionString("Management");
            await using var conn = new SqlConnection(cs);
            await conn.OpenAsync();
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT 1";
            var result = await cmd.ExecuteScalarAsync();
            return Results.Ok(new { db = "ok", result });
        })
        .WithName("HealthDb");
    }
}
