using Api.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Data API", Version = "v1" });
});

// --- DbContext を DI 登録 ---
// DbContext 側（DLL側）が OnConfiguring() で UseSqlServer(GetConnectionString()) を行う前提。
// そのため、API側では接続文字列を読まない / UseSqlServer を呼ばない。
//builder.Services.AddDbContext<NsecDB.jobwebContext>();
//builder.Services.AddDbContext<NsecDB.NsecManagementContext>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

var v1 = app.MapGroup("/v1");

// ★ 反射で Endpoints を一括登録
v1.MapDiscoveredEndpoints(app.Services, typeof(Program).Assembly);

app.Run();