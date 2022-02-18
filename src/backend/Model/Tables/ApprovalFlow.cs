using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables;

/// <summary>承認フローテーブル</summary>
public class ApprovalFlow : TableBase
{
    /// <summary>承認フローID</summary>
    [Key]
    public string ApprovalFlowID { get; init; } = string.Empty;

    /// <summary>グループID</summary>
    [ForeignKey(nameof(Group))]
    public string GroupID { get; set; } = string.Empty;

    /// <summary>グループ</summary>
    public virtual Group Group { get; set; } = null!;

    /// <summary>承認者ID</summary>
    [ForeignKey(nameof(Approver))]
    public string ApproverID { get; set; } = string.Empty;

    /// <summary>承認者</summary>
    public virtual User Approver { get; set; } = null!;

    /// <summary>承認順序</summary>
    public int ApprovalOrder { get; set; }
}