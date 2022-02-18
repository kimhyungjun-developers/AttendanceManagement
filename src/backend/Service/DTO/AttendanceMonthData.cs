using Model.Tables;

namespace Service.DTO;

/// <summary>勤怠月間DTO</summary>
public record AttendanceMonthData(
    string AttendanceMonthId,
    string UserId,
    string TargetMonth,
    int ApprovalStatus
    )
{
    /// <summary>コンストラクタ</summary>
    public AttendanceMonthData(AttendanceMonth attendanceMonth) : this(
        attendanceMonth.AttendanceMonthID,
        attendanceMonth.UserID,
        attendanceMonth.TargetMonth.ToString(),
        attendanceMonth.Confirmed ? 1 : 0)
    { }
}