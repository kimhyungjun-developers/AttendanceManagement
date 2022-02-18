using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables;

/// <summary>勤怠月間テーブル</summary>
public class AttendanceMonth : TableBase
{
    /// <summary>勤怠月間ID</summary>
    [Key]
    public string AttendanceMonthID { get; init; } = string.Empty;

    /// <summary>ユーザーID</summary>
    [ForeignKey(nameof(User))]
    public string UserID { get; } = string.Empty;

    /// <summary>ユーザー</summary>
    public virtual User User { get; set; } = null!;

    /// <summary>対象年月</summary>
    public DateOnly TargetMonth { get; }

    /// <summary>確定済みフラグ</summary>
    public bool Confirmed { get; set; }

    /// <summary>勤怠詳細を識別するためのキー情報</summary>
    public virtual ICollection<AttendanceDetail> AttendanceDetail { get; set; } = null!;

    /// <summary>承認履歴を識別するためのキー情報</summary>
    public virtual ICollection<ApprovalHistory> ApprovalHistory { get; set; } = null!;
}