using Microsoft.AspNetCore.Mvc.Filters;

namespace WebAPI.Filters;

/// <summary>結果ログフィルター</summary>
public class ResultServiceFilter : IResultFilter
{
    /// <inheritdoc />
    public void OnResultExecuted(ResultExecutedContext context)
    {
    }

    /// <inheritdoc />
    public void OnResultExecuting(ResultExecutingContext context)
    {
        context.HttpContext.Response.StatusCode = context.HttpContext.Request.Method switch
        {
            "GET" => StatusCodes.Status200OK,
            "POST" or "PUT" => StatusCodes.Status201Created,
            "DELETE" => StatusCodes.Status204NoContent,
            _ => StatusCodes.Status200OK
        };
    }
}