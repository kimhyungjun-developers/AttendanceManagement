using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Model.DataContext;

/// <summary>SQLiteのデータコンテキストベースクラス</summary>
public sealed class SQLiteDataContext : DataContextBase
{
    /// <summary接続</summary>
    private SqliteConnection? Connection { get; set; }

    /// <summary>破棄処理</summary>
    public override void Dispose()
    {
        base.Dispose();
        Connection?.Dispose();
    }

    /// <summary>破棄処理</summary>
    public override async ValueTask DisposeAsync()
    {
        await base.DisposeAsync();
        if (Connection != null) await Connection.DisposeAsync();
    }

    /// <summary>設定情報の更新</summary>
    /// <param name="optionsBuilder">オプションビルダ</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Connection = new SqliteConnection("Filename=:memory:");
        Connection.Open();
        optionsBuilder.UseSqlite(Connection);
    }
}