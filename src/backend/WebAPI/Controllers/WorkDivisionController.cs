using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>勤務区分コントローラー</summary>
[ApiController]
[Route("api/workDivisions")]
public class WorkDivisionController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<WorkDivisionController> logger;

    /// <summary>コンストラクタ</summary>
    public WorkDivisionController(ILogger<WorkDivisionController> logger)
    {
        this.logger = logger;
    }

    /// <summary>勤務区分の一覧の取得</summary>
    [HttpGet]
    [Authorize]
    public async Task<RequestResult<WorkDivisionData>> GetAllAsync()
    {
        await Task.FromResult(0);
        return new();
    }
}