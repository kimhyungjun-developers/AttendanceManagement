using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Authentications;
using Service.DTO;
using System.Security.Claims;

namespace WebAPI.Controllers;

/// <summary>ユーザー認証コントローラー</summary>
[ApiController]
[Route("api/authentications")]
public class AuthenticationController : ControllerBase
{
    /// <summary>ログイン検証サービス</summary>
    private readonly LoginChecker loginChecker;

    /// <summary>ログインユーザー取得サービス</summary>
    private readonly LoginUserGetter loginUserGetter;

    /// <summary>ロガー</summary>
    private readonly ILogger<AuthenticationController> logger;

    /// <summary>コンストラクタ</summary>
    public AuthenticationController(LoginChecker loginChecker, LoginUserGetter loginUserGetter, ILogger<AuthenticationController> logger)
    {
        this.loginChecker = loginChecker;
        this.loginUserGetter = loginUserGetter;
        this.logger = logger;
    }

    /// <summary>ログイン</summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<RequestResult> LoginAsync(AuthenticationLoginRequest request)
    {
        logger.LogInformation("ログイン開始", request.Email);

        try
        {
            var userID = await loginChecker.CheckAsync(request.Email, request.Password);

            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userID) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(identity);
            var authenticationProperties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
            logger.LogInformation("ログイン成功", request.Email);
            return new();
        }
        catch (ArgumentException ex)
        {
            logger.LogError("ログイン失敗", ex.Message);
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return new(ex.Message);
        }
    }

    /// <summary>ログアウト</summary>
    [HttpPost("logout")]
    [Authorize]
    public async Task<RequestResult> LogoutAsync()
    {
        var userID = HttpContext.User.Claims.First().Value;
        logger.LogInformation("ログアウト開始", userID);
        try
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            logger.LogInformation("ログアウト成功", userID);
            return new();
        }
        catch (ArgumentException ex)
        {
            logger.LogError("ログアウト失敗", ex.Message);
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return new(ex.Message);
        }
    }

    /// <summary>管理者によるパスワード強制更新</summary>
    [HttpPost("{userId}/password/forceChange")]
    [Authorize("AdministratorPolicy")]
    public async Task<RequestResult> ForceChangePasswordAsync(string userId)
    {
        await Task.FromResult(0);
        return new();
    }

    /// <summary>ログイン中ユーザーの取得</summary>
    [HttpGet]
    [Authorize]
    public async Task<RequestResult<UserData>> GetAsync()
    {
        var userID = HttpContext.User.Claims.First().Value;
        logger.LogInformation("ユーザー取得", userID);
        try
        {
            return new(await loginUserGetter.GetAsync(userID));
        }
        catch (ArgumentException ex)
        {
            logger.LogError("ユーザー取得失敗", ex.Message);
            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            return new(null, ex.Message);
        }
    }

    /// <summary>パスワード更新</summary>
    [HttpPut("password")]
    [Authorize]
    public async Task<RequestResult> UpdateAsync(AuthenticationUpdateRequest request)
    {
        var operatorID = HttpContext.User.Claims.First().Value;

        await Task.FromResult(0);
        return new();
    }

    /// <summary>ログインリクエスト</summary>
    public record AuthenticationLoginRequest(string Email, string Password);

    /// <summary>パスワード更新リクエスト</summary>
    public record AuthenticationUpdateRequest(string Password, string ProgramName);
}