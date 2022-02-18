using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>勤怠コントローラー</summary>
[ApiController]
[Route("api/attendances")]
public class AttendanceController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<AttendanceController> logger;

    /// <summary>コンストラクタ</summary>
    public AttendanceController(ILogger<AttendanceController> logger)
    {
        this.logger = logger;
    }

    /// <summary>勤務表ダウンロード</summary>
    [HttpPost("download")]
    [Authorize]
    public async Task<RequestResult> DownloadAsync(AttendanceDownloadRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>勤怠月間の取得</summary>
    [HttpGet("{year}/{month}")]
    [Authorize]
    public async Task<RequestResult<AttendanceMonthData>> GetAsync(string year, string month)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>対象ユーザーの勤怠月間の取得</summary>
    [HttpGet("{userId}/{year}/{month}")]
    [Authorize]
    public async Task<RequestResult<AttendanceMonthData>> GetAsync(string userId, string year, string month)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>勤怠月間の更新</summary>
    [HttpPut("{year}/{month}")]
    [Authorize]
    public async Task<RequestResult<AttendanceMonthData>> UpdateAsync(string year, string month, AttendanceMonthUpdateRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>勤怠詳細の更新</summary>
    [HttpPut("{year}/{month}/{date}")]
    [Authorize]
    public async Task<RequestResult<AttendanceDetailData>> UpdateAsync(string year, string month, string date, AttendanceDetailUpdateRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>勤務表ダウンロードリクエスト</summary>
    public record AttendanceDownloadRequest(string[] UserIds);

    /// <summary>勤怠月間更新リクエスト</summary>
    public record AttendanceMonthUpdateRequest(string DefaultStartTime, string DefaultEndTime, string DefaultRestTime, string ProgramName);

    /// <summary>勤怠詳細更新リクエスト</summary>
    public record AttendanceDetailUpdateRequest(
        string WorkDirivisonId,
        string TargetDate,
        string StartDateTime,
        string EndDateTime,
        string RestTime,
        string ActualTime,
        string OverTime,
        string MidnightTime,
        string Note,
        string ProgramName);
}