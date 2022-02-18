namespace WebAPI;

/// <summary>リクエスト結果</summary>
public struct RequestResult
{
    /// <summary>コンストラクタ</summary>
    /// <param name="errorMessage">エラーメッセージ</param>
    public RequestResult(string? errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    /// <summary>リクエストの成否</summary>
    public bool Success => ErrorMessage == null;

    /// <summary>エラーメッセージ</summary>
    public string? ErrorMessage { get; }
}

/// <summary>リクエスト結果</summary>
/// <typeparam name="T">結果の型</typeparam>
public struct RequestResult<T>
{
    /// <summary>コンストラクタ</summary>
    /// <param name="result">結果</param>
    /// <param name="errorMessage">エラーメッセージ</param>
    public RequestResult(T? result, string? errorMessage = null)
    {
        Result = result;
        ErrorMessage = null;
    }

    /// <summary>結果</summary>
    public T? Result { get; }

    /// <summary>リクエストの成否</summary>
    public bool Success => ErrorMessage == null;

    /// <summary>エラーメッセージ</summary>
    public string? ErrorMessage { get; }
}