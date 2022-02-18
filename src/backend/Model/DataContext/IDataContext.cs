using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Model.Tables;

namespace Model.DataContext;

/// <summary>データコンテキスト</summary>
public interface IDataContext : IDisposable, IAsyncDisposable
{
    /// <summary>ユーザー</summary>
    DbSet<User> Users { get; }

    /// <summary>ユーザー認証</summary>
    DbSet<Authentication> Authentications { get; }

    /// <summary>権限</summary>
    DbSet<Authority> Authorities { get; }

    /// <summary>グループ</summary>
    DbSet<Group> Groups { get; }

    /// <summary>承認フロー</summary>
    DbSet<ApprovalFlow> ApprovalFlows { get; }

    /// <summary>承認履歴</summary>
    DbSet<ApprovalHistory> ApprovalHistories { get; }

    /// <summary>勤怠月間管理</summary>
    DbSet<AttendanceMonth> AttendanceMonths { get; }

    /// <summary>勤怠詳細</summary>
    DbSet<AttendanceDetail> AttendanceDetails { get; }

    /// <summary>勤務区分</summary>
    DbSet<WorkDivision> WorkDivisions { get; }

    /// <summary>休日</summary>
    DbSet<Holiday> Holidays { get; }

    /// <summary>トランザクションを開始する</summary>
    public Task BeginTransactionAsync();

    /// <summary>トランザクションをコミットする</summary>
    public Task CommitAsync();

    /// <summary>変更の保存</summary>
    /// <returns>変更を及ぼした行数</returns>
    int SaveChanges();

    /// <summary>指定されたエンティティに関する情報を取得する</summary>
    /// <param name="entity">情報取得対象のエンティティ</param>
    /// <returns>エンティティに関する情報</returns>
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    /// <summary>変更の保存</summary>
    /// <param name="cancellationToken">処理キャンセル用トークン</param>
    /// <returns>変更を及ぼした行数</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}