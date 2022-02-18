using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

/// <summary>例外ログフィルター</summary>
public class LogWriteExceptionFilter : IExceptionFilter
{
    /// <summary>ロガー</summary>
    private readonly ILogger<LogWriteExceptionFilter> logger;

    /// <summary>コンストラクタ</summary>
    /// <param name="logger">ロガー</param>
    public LogWriteExceptionFilter(ILogger<LogWriteExceptionFilter> logger)
    {
        this.logger = logger;
    }

    /// <inheritdoc />
    public void OnException(ExceptionContext context)
    {
        logger.LogError(context.Exception.ToString());
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
    }
}