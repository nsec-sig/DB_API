# Data API (DI版 / Endpointsは反射で一括登録) + Models

## 目的
- Minimal API で Endpoints を **反射(Reflection)で自動登録**
- DbContext を **DI(AddDbContext)** で構成して Endpoints に注入
- Model は `src/Api/Models/` に配置（Swagger Codegen由来のモデルを同梱）

## 起動
1) `docker-compose.yml` の接続文字列を社内SQL Serverに合わせて変更
- `ConnectionStrings__Jobweb`
- `ConnectionStrings__Management`

2) 実行
```bash
docker compose build
docker compose up -d
```

Swagger:
- http://localhost:8080/swagger

疎通:
- GET http://localhost:8080/v1/health
- GET http://localhost:8080/v1/health/db

部署一覧:
- GET http://localhost:8080/v1/depts

## エンドポイント追加方法
`src/Api/Endpoints/` に `IEndpoint` 実装クラスを追加し、ビルドすれば自動登録されます。
```bash
docker compose up -d --build
```

## 前提
- `NsecDB.jobwebContext` と `NsecDB.NsecManagementContext` が Api プロジェクトから参照できること
  - 別プロジェクトの場合は `Api.csproj` に ProjectReference を追加してください。
