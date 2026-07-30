using Api.Infrastructure;
using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NsecDB;

namespace Api.Endpoints;

/// <summary>
/// 部署一覧取得 (Master)
/// </summary>
public sealed class DeptsEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routes)
    {
        routes.MapGet("/depts", DeptsGet)
            .WithName("DeptsGet")
            .WithTags("Master")
            .WithSummary("部署一覧取得 (Master)")
            .Produces<List<Dept>>(StatusCodes.Status200OK)
            .WithOpenApi(op =>
            {
                op.OperationId = "DeptsGet";
                op.Responses["200"] = new OpenApiResponse { Description = "Array of Dept" };
                return op;
            });
    }

    // ★ Minimal API の引数で DbContext を DI 注入
    private static async Task<IResult> DeptsGet()
    {
        using ( var jobwebContext = new NsecDB.jobwebContext() )
        using ( var managementContext = new NsecDB.NsecManagementContext() )
        {
            var deptDict = (await jobwebContext.DepartmentCodes.ToListAsync())
                .ToDictionary(x => x.DeptCd, x => x);

            var soDict = (await jobwebContext.SoCodes.ToListAsync())
                .ToDictionary(x => x.SoCd, x => x);

            // 元コードの意図（DelFlg==0 を抽出し、DivisionType を参照）を維持
            var divisions = await managementContext.SDivisions
                .Where(x => x.DelFlg == 0)
                .Include(x => x.DivisionType)
                .ToListAsync();

            var result = divisions
                .Select(x =>
                {
                    string code = "";
                    string name = "";

                    if ((x.DivisionTypeId == 1) && (soDict.TryGetValue((byte)x.SoId, out var s)))
                    {
                        code = s.SoCd.ToString();
                        name = s.SoName;
                    }
                    else if ((x.DivisionTypeId == 2) && (deptDict.TryGetValue(x.DeptId?.ToString() ?? "", out var d)))
                    {
                        code = d.DeptCd;
                        name = d.DeptName;
                    }

                    return new Dept
                    {
                        Id = x.Id,
                        DivisionType = x.DivisionType.Name,
                        Note = x.Note,
                        SortKey = x.SortKey,
                        DeptCode = code,
                        DeptName = name
                    };
                })
                .ToList();
            return Results.Ok(result);
        }
    }
}
