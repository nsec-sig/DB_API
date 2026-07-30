using Api.Infrastructure;
using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NsecDB;

namespace Api.Endpoints;

/// <summary>
/// Division一覧取得
/// </summary>
public sealed class SDivisionsEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routes)
    {
        routes.MapGet("/s-divisions", SDivisionsGet)
            .WithName("SDivisionsGet")
            .WithTags("Master")
            .WithSummary("Division一覧取得")
            .Produces<List<SDivisionListItemDto>>(StatusCodes.Status200OK)
            .WithOpenApi(op =>
            {
                op.OperationId = "SDivisionsGet";
                op.Responses["200"] = new OpenApiResponse { Description = "Array of SDivisionListItemDto" };
                return op;
            });
    }

    private static async Task<IResult> SDivisionsGet()
    {
        await using var managementContext = new NsecManagementContext();

        var result = await managementContext.SDivisions
            .Where(x => x.DelFlg == 0)
            .Include(x => x.DivisionType)
            .Select(x => new SDivisionListItemDto
            {
                Id = x.Id,
                DelFlg = x.DelFlg,
                DivisionTypeId = x.DivisionTypeId,
                DivisionTypeName = x.DivisionType != null ? x.DivisionType.Name : "",

                SoId = x.SoId,
                DeptId = x.DeptId,
                SortKey = x.SortKey,

                Note = x.Note ?? "",
                RegUserId = x.RegUserId,
                RegDate = x.RegDate
            })
            .ToListAsync();

        return Results.Ok(result);
    }
}