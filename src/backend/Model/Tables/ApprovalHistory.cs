using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables;

/// <summary>承認履歴テーブル</summary>
public class ApprovalHistory : TableBase
{
    /// <summary>承認履歴ID</summary>
    [Key]
    public string ApprovalHistoryID { get; init; } = string.Empty;

    /// <summary>勤怠月間管理ID</summary>
    [ForeignKey(nameof(AttendanceMonth))]
    public string AttendanceMonthID { get; } = string.Empty;

    /// <summary>勤怠月間管理</summary>
    public virtual AttendanceMonth AttendanceMonth { get; set; } = null!;

    /// <summary>承認者ID</summary>
    [ForeignKey(nameof(Approver))]
    public string ApproverID { get; set; } = string.Empty;

    /// <summary>承認者</summary>
    public virtual User Approver { get; set; } = null!;

    /// <summary>承認フラグ</summary>
    public bool Approved { get; set; }

    /// <summary>日付</summary>
    public DateTime Date { get; set; }

    /// <summary>コメント</summary>
    public string? Comment { get; set; } = null;
}