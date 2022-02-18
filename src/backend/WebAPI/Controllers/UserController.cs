using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.DTO;

namespace WebAPI.Controllers;

/// <summary>ユーザーコントローラー</summary>
[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    /// <summary>ロガー</summary>
    private readonly ILogger<UserController> logger;

    /// <summary>コンストラクタ</summary>
    public UserController(ILogger<UserController> logger)
    {
        this.logger = logger;
    }

    /// <summary>ユーザーの追加</summary>
    [HttpPost]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> AddAsync(UserAddRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>ユーザーの取得</summary>
    [HttpGet("{id}")]
    [Authorize]
    public async Task<RequestResult<UserData>> GetAsync(string id)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>ユーザーの全件取得</summary>
    [HttpGet]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult<IEnumerable<UserData>>> GetAllAsync()
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>ユーザーの更新</summary>
    [HttpPut("{userId}")]
    [Authorize]
    public async Task<RequestResult<UserData>> UpdateAsync(string userId, UserUpdateRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>管理者によるユーザーの更新</summary>
    [HttpPut("{userId}/authority")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult<UserData>> UpdateByAdministratorAsync(string userId, UserUpdateByAdministratorRequest request)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>ユーザーの削除</summary>
    [HttpDelete("{userId}")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> DeleteAsync(string userId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>ユーザー追加リクエスト</summary>
    public record UserAddRequest(
        string EmployeeNumber,
        string FirstName,
        string LastName,
        string FirstNameFurigana,
        string LastNameFurigana,
        string Email,
        string AuthorityId,
        string GroupId,
        string ProgramName
        );

    /// <summary>ユーザー更新リクエスト</summary>
    public record UserUpdateRequest(
        string FirstName,
        string LastName,
        string FirstNameFurigana,
        string LastNameFurigana,
        string Email,
        string DefaultStartTime,
        string DefaultEndTime,
        string DefaultRestTime,
        string ProgramName
        );

    /// <summary>管理者によるユーザー更新リクエスト</summary>
    public record UserUpdateByAdministratorRequest(
        string AuthorityId,
        string GroupId,
        string ProgramName
        );
}