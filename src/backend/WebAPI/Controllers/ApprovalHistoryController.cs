using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>承認履歴コントローラー</summary>
[ApiController]
[Route("api/approvalHistories")]
public class ApprovalHistoryController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<ApprovalHistoryController> logger;

    /// <summary>コンストラクタ</summary>
    public ApprovalHistoryController(ILogger<ApprovalHistoryController> logger)
    {
        this.logger = logger;
    }

    /// <summary>承認履歴を追加する</summary>
    [HttpPost("{attendanceMonthID}")]
    [Authorize]
    public async Task<RequestResult> AddAsync(string attendanceMonthID, ApprovalHistoryAddRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>承認履歴を取得する</summary>
    [HttpGet("{attendanceMonthID}")]
    [Authorize]
    public async Task<RequestResult<IEnumerable<ApprovalHistoryData>>> GetAsync(string attendanceMonthID)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>承認履歴追加リクエスト</summary>
    public record ApprovalHistoryAddRequest(bool Approved, string Comment);
}