using Api.Infrastructure;
using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NsecDB;

namespace Api.Endpoints;

/// <summary>
/// 権限マスタ一覧取得
/// </summary>
public sealed class MAuthoritiesEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routes)
    {
        routes.MapGet("/m-authorities", MAuthoritiesGet)
            .WithName("MAuthoritiesGet")
            .WithTags("Master")
            .WithSummary("権限マスタ一覧取得")
            .Produces<List<MAuthorityDto>>(StatusCodes.Status200OK)
            .WithOpenApi(op =>
            {
                op.OperationId = "MAuthoritiesGet";
                op.Responses["200"] = new OpenApiResponse { Description = "Array of MAuthorityDto" };
                return op;
            });
    }

    private static async Task<IResult> MAuthoritiesGet()
    {
        await using var managementContext = new NsecManagementContext();

        var result = await managementContext.MAuthorities
            .Select(x => new MAuthorityDto
            {
                Id = x.Id,
                Name = x.Name,
                Note = x.Note ?? "",
                RegDate = x.RegDate
            })
            .ToListAsync();

        return Results.Ok(result);
    }
}