using Model.Enum;

namespace Model.Tables;

/// <summary>勤怠詳細テーブル</summary>
public class AttendanceDetail : TableBase
{
    /// <summary>勤怠詳細ID</summary>
    public string AttendanceDetailID { get; init; } = string.Empty;

    /// <summary>勤怠月間管理ID</summary>
    public string AttendanceMonthID { get; } = string.Empty;

    /// <summary>勤怠月間管理</summary>
    public virtual AttendanceMonth AttendanceMonth { get; set; } = null!;

    /// <summary>勤務区分ID</summary>
    public WorkDivisions WorkDivisionID { get; set; }

    /// <summary>対象日付</summary>
    public DateOnly Date { get; set; }

    /// <summary>作業開始日時</summary>
    public DateTime? StartDate { get; set; }

    /// <summary>作業終了日時</summary>
    public DateTime? EndDate { get; set; }

    /// <summary>休憩時間</summary>
    public TimeSpan? RestTime { get; set; }

    /// <summary>実稼働時間</summary>
    public TimeSpan? ActualTime { get; set; }

    /// <summary>残業時間</summary>
    public TimeSpan? OverTime { get; set; }

    /// <summary>深夜作業時間</summary>
    public TimeSpan? MidnightTime { get; set; }

    /// <summary>平休日区分</summary>
    public int WeekdayDivision { get; set; }

    /// <summary>メモ</summary>
    public string? Note { get; set; } = null;
}