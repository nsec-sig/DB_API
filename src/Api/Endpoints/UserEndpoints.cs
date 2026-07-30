using Api.Infrastructure;
using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NsecDB.Formats.JobWeb;

namespace Api.Endpoints;

/// <summary>
/// ユーザ一覧取得 (Master)
/// </summary>
public sealed class UserEndpoints : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder routes)
    {
        routes.MapGet("/users", UsersGet)
            .WithName("UsersGet")
            .WithTags("Master")
            .WithSummary("ユーザ一覧取得 (Master)")
            .Produces<List<User>>(StatusCodes.Status200OK)
            .WithOpenApi(op =>
            {
                op.OperationId = "UsersGet";
                op.Responses["200"] = new OpenApiResponse { Description = "Array of User" };
                return op;
            });
    }

    /// <summary>
    /// Minimal API: 引数で DI 注入される (dept_code は QueryString から自動バインド)
    /// </summary>
    private static async Task<IResult> UsersGet(
        string? dept_code)
    {
        // 元コード互換：dept_code が int に変換できない場合は空配列返却（200 OK）
        if (!int.TryParse(dept_code ?? string.Empty, out var d))
        {
            return Results.Ok(new List<User>());
        }
        using ( var context = new NsecDB.jobwebContext() )
        {
            var query = context.VwUserTables
                .Where( x => x.DelFlg == 0 )
                ;

            if ( d < 20 )
            {
                query = query
                    .Where( x => ( x.f_Department1.SoCd == d ) || ( x.f_Department2.SoCd == d ) )
                    ;
            }
            else
            {
                query = query
                    .Where( x => ( x.DeptCd == dept_code ) || ( x.DeptCd2 == dept_code ) )
                    ;
            }

            var users = await query
                .ToListAsync()
                ;

            var result = users
                .OrderBy( x => int.TryParse( x.UserId ?? "", out var u ) ? u : -1 )
                .Select( x => ConvertUser( x ) )
                .ToList();

            return Results.Ok(result);
        }

    }
    private static User ConvertUser( VwUserTable x )
    {
        return new User()
        {
            UserId = x.UserId,
            UserName = x.UserName,
            UserPassWord = x.Password,
            UserAdmin = x.Admin
        };
    }

}
