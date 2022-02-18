using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>権限コントローラー</summary>
[ApiController]
[Route("api/authorities")]
public class AuthorityController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<AuthorityController> logger;

    /// <summary>コンストラクタ</summary>
    public AuthorityController(ILogger<AuthorityController> logger)
    {
        this.logger = logger;
    }

    /// <summary>権限一覧の取得</summary>
    [HttpGet]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult<IEnumerable<AuthorityData>>> GetAllAsync()
    {
        await Task.FromResult(0);
        return new();
    }
}