using System.ComponentModel.DataAnnotations;

namespace Model.Tables;

/// <summary>グループテーブル</summary>
public class Group : TableBase
{
    /// <summary>グループID</summary>
    [Key]
    public string GroupID { get; init; } = string.Empty;

    /// <summary>グループ名</summary>
    public string GroupName { get; set; } = string.Empty;

    /// <summary>ユーザーを識別するためのキー情報</summary>
    public virtual ICollection<User> User { get; set; } = null!;

    /// <summary>承認フローを識別するためのキー情報</summary>
    public virtual ICollection<ApprovalFlow> ApprovalFlow { get; set; } = null!;
}