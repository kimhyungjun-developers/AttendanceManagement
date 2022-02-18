using Microsoft.AspNetCore.Authorization;
using Model.DataServices;

namespace WebAPI.Policies;

/// <summary>管理者認証ハンドラ</summary>
public sealed class AdministratorAuthorizationHandler : AuthorizationHandler<AdministratorRequirement>, IDisposable
{
    /// <summary>データサービス</summary>
    private readonly IDataService dataService;

    /// <summary>コンストラクタ</summary>
    /// <param name="dataService">データサービス</param>
    public AdministratorAuthorizationHandler(IDataService dataService)
    {
        this.dataService = dataService;
    }

    /// <summary>認証処理</summary>
    /// <param name="context">コンテキスト</param>
    /// <param name="requirement">必須オブジェクト</param>
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdministratorRequirement requirement)
    {
        await Task.FromResult(0);
    }

    /// <summary>破棄処理</summary>
    public void Dispose() => dataService.Dispose();
}