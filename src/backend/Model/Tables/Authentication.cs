using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables;

/// <summary>ユーザー認証テーブル</summary>
public class Authentication : TableBase
{
    /// <summary>ユーザーID</summary>
    [Key, ForeignKey(nameof(User))]
    public string UserID { get; init; } = string.Empty;

    /// <summary>ユーザー</summary>
    public virtual User User { get; set; } = null!;

    /// <summary>ハッシュ化したパスワード</summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>パスワードソルト</summary>
    public string PasswordSalt { get; set; } = string.Empty;
}