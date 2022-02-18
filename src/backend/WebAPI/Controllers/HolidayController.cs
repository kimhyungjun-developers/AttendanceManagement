using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>休日コントローラー</summary>
[ApiController]
[Route("api/holidays")]
public class HolidayController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<HolidayController> logger;

    /// <summary>コンストラクタ</summary>
    public HolidayController(ILogger<HolidayController> logger)
    {
        this.logger = logger;
    }

    /// <summary>休日の追加</summary>
    [HttpPost]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> AddAsync(HolidayAddRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>対象期間の休日一覧の取得</summary>
    [HttpGet("targetPeriod")]
    [Authorize]
    public async Task<RequestResult<IEnumerable<HolidayData>>> GetAsync([FromQuery] string targetStartDate, [FromQuery] string targetEndDate)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>休日の取得</summary>
    [HttpGet("{holidayId}")]
    [Authorize]
    public async Task<RequestResult<HolidayData>> GetAsync(string holidayId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>休日一覧の取得</summary>
    [HttpGet]
    [Authorize]
    public async Task<RequestResult<IEnumerable<HolidayData>>> GetAllAsync()
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>休日の更新</summary>
    [HttpPut("{holidayId}")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult<HolidayData>> UpdateAsync(string holidayId, HolidayUpdateRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>休日の削除</summary>
    [HttpDelete("{holidayId}")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> DeleteAsync(string holidayId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>休日追加リクエスト</summary>
    public record HolidayAddRequest(string TargetDate, string HolidayName, string ProgramName);

    /// <summary>休日更新リクエスト</summary>
    public record HolidayUpdateRequest(string TargetDate, string HolidayName, string ProgramName);
}