using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>承認フローコントローラー</summary>
[ApiController]
[Route("api/approvalFlows")]
public class ApprovalFlowController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<ApprovalFlowController> logger;

    /// <summary>コンストラクタ</summary>
    public ApprovalFlowController(ILogger<ApprovalFlowController> logger)
    {
        this.logger = logger;
    }

    /// <summary>承認フローの追加</summary>
    [HttpPost]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> AddAsync(ApprovalFlowAddRequest[] requests)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>承認フローの取得</summary>
    [HttpGet("{groupId}")]
    [Authorize]
    public async Task<RequestResult<IEnumerable<ApprovalFlowData>>> GetAsync(string groupId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>承認フローの更新</summary>
    [HttpPut("{approvalFlowId}")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult<ApprovalFlowData>> UpdateAsync(string approvalFlowId, ApprovalFlowUpdateRequest[] request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>承認フローの削除</summary>
    [HttpDelete("{approvalFlowId}")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> DeleteAsync(string approvalFlowId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>承認フロー追加リクエスト</summary>
    public record ApprovalFlowAddRequest(string ApproverId, int ApprovalOrder);

    /// <summary>承認フロー更新リクエスト</summary>
    public record ApprovalFlowUpdateRequest(string ApproverId, int ApprovalOrder);
}