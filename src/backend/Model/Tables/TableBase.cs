namespace Model.Tables;

/// <summary>共通ベーステーブル</summary>
public class TableBase
{
    /// <summary>作成日</summary>
    public DateTime? CreateDate { get; set; }

    /// <summary>作成者</summary>
    public string? CreateUser { get; set; } = string.Empty;

    /// <summary>作成プログラム</summary>
    public string? CreateProgram { get; set; } = string.Empty;

    /// <summary>更新日</summary>
    public DateTime? UpdateDate { get; set; }

    /// <summary>更新者</summary>
    public string? UpdateUser { get; set; } = string.Empty;

    /// <summary>更新プログラム</summary>
    public string? UpdateProgram { get; set; } = string.Empty;
}