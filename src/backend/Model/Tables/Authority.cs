using Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Model.Tables;

/// <summary>権限テーブル</summary>
public class Authority : TableBase
{
    /// <summary>権限ID</summary>
    [Key]
    public Authorities AuthorityID { get; init; }

    /// <summary>権限名</summary>
    public string AuthorityName { get; set; } = string.Empty;

    /// <summary>ユーザーを識別するためのキー情報</summary>
    public virtual ICollection<User> User { get; set; } = null!;
}