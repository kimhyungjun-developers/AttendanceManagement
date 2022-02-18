using Model.Tables;

namespace Model.DataServices;

/// <summary>データサービス</summary>
public interface IDataService : IDisposable, IAsyncDisposable
{
    /// <summary>変更の保存をする</summary>
    int SaveChanges();

    /// <summary>非同期的に変更の保存をする</summary>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>トランザクションを開始する</summary>
    Task BeginTransactionAsync();

    /// <summary>トランザクションをコミットする</summary>
    Task CommitAsync();

    /// <summary>ユーザーの存在確認</summary>
    Task<bool> IsExistUserAsync(string userID);

    /// <summary>ユーザーを取得する</summary>
    Task<User?> GetUserByMailAddressAsync(string mailAddress);

    /// <summary>ユーザーを取得する</summary>
    Task<User?> GetUserByUserIDAsync(string userID);

    /// <summary>ログイン検証をする</summary>
    Task<bool> CanLoginAsync(string userID, string password);
}