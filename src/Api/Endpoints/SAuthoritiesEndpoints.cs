using Api.Infrastructure;
using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NsecDB;

namespace Api.Endpoints;

/// <summary>
/// 権限割当一覧取得
/// </summary>
public sealed class SAuthoritiesEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routes)
    {
        routes.MapGet("/s-authorities", SAuthoritiesGet)
            .WithName("SAuthoritiesGet")
            .WithTags("Master")
            .WithSummary("権限割当一覧取得")
            .Produces<List<SAuthorityListItemDto>>(StatusCodes.Status200OK)
            .WithOpenApi(op =>
            {
                op.OperationId = "SAuthoritiesGet";
                op.Responses["200"] = new OpenApiResponse { Description = "Array of SAuthorityListItemDto" };
                return op;
            });
    }

    private static async Task<IResult> SAuthoritiesGet()
    {
        await using var managementContext = new NsecManagementContext();

        var result = await managementContext.SAuthorities
            // DelFlg があるならフィルタ（あなたの Depts と同じ思想）
            .Where(x => x.DelFlg == 0)
            // 必要な参照だけ include（Authority.Name / Divisionの項目）
            .Include(x => x.Authority)
            .Include(x => x.Division)
            // DTOへ投影（Selectを先に書けるなら、Include不要でJOIN化されます）
            .Select(x => new SAuthorityListItemDto
            {
                Id = x.Id,
                UserId = x.UserId,
                AuthorityId = x.AuthorityId,
                AuthorityName = x.Authority != null ? x.Authority.Name : "",

                DivisionId = x.DivisionId,
                DivisionTypeId = x.Division != null ? x.Division.DivisionTypeId : null,
                SoId = x.SoId,
                DeptId = x.DeptId,

                Note = x.Note ?? "",
                RegUserId = x.RegUserId,
                RegDate = x.RegDate
            })
            .ToListAsync();

        return Results.Ok(result);
    }
}