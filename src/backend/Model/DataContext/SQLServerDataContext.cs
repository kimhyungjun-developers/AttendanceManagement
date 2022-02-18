using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Model.DataContext;

/// <summary>SQLServerのデータコンテキストクラス</summary>
public sealed class SQLServerDataContext : DataContextBase
{
    /// <summary>接続文字列</summary>
    private readonly string connectionString;

    /// <summary>コンストラクタ</summary>
    /// <param name="config">設定オブジェクト</param>
    public SQLServerDataContext(IOptions<Config> config)
    {
        connectionString = config.Value.ConnectionString;
    }

    /// <summary>設定値の変更処理</summary>
    /// <param name="optionsBuilder">オプション構成オブジェクト</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(connectionString, providerOptions => providerOptions.CommandTimeout(60).EnableRetryOnFailure());
}