using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>グループコントローラー</summary>
[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<GroupController> logger;

    /// <summary>コンストラクタ</summary>
    public GroupController(ILogger<GroupController> logger)
    {
        this.logger = logger;
    }

    /// <summary>グループの追加</summary>
    [HttpPost]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> AddAsync(GroupAddRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>グループの取得</summary>
    [HttpGet("{groupId}")]
    [Authorize]
    public async Task<RequestResult<GroupData>> GetAsync(string groupId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>グループの全件取得</summary>
    [HttpGet]
    [Authorize]
    public async Task<RequestResult<IEnumerable<GroupData>>> GetAllAsync()
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>グループの更新</summary>
    [HttpPut("{groupId}")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> UpdateAsync(string groupId, GroupUpdateRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>グループの削除</summary>
    [HttpDelete("groupId")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> DeleteAsync(string groupId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>グループ追加リクエスト</summary>
    public record GroupAddRequest(string GroupName, string ProgramName);

    /// <summary>グループ更新リクエスト</summary>
    public record GroupUpdateRequest(string GroupName, string ProgramName);
}