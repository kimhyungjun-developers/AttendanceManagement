using Model.Tables;

namespace Service.DTO;

/// <summary>勤怠詳細DTO</summary>
public record AttendanceDetailData(
    string AttendanceDetailId,
    string WorkDivisionId,
    string Date,
    string StartDateTime,
    string EndDateTime,
    string RestTime,
    string ActualTime,
    string OverTime,
    string MidnightTime,
    int WeekdayDivision,
    string Note)
{
    /// <summary>コンストラクタ</summary>
    public AttendanceDetailData(AttendanceDetail attendanceDetail) : this(
        attendanceDetail.AttendanceDetailID,
        attendanceDetail.WorkDivisionID.ToString(),
        attendanceDetail.Date.ToString(),
        attendanceDetail.StartDate == null ? string.Empty : attendanceDetail.StartDate.Value.ToString(),
        attendanceDetail.EndDate == null ? string.Empty : attendanceDetail.EndDate.Value.ToString(),
        attendanceDetail.RestTime == null ? string.Empty : attendanceDetail.RestTime.Value.ToString(),
        attendanceDetail.ActualTime == null ? string.Empty : attendanceDetail.ActualTime.Value.ToString(),
        attendanceDetail.OverTime == null ? string.Empty : attendanceDetail.OverTime.Value.ToString(),
        attendanceDetail.MidnightTime == null ? string.Empty : attendanceDetail.MidnightTime.Value.ToString(),
        attendanceDetail.WeekdayDivision,
        attendanceDetail.Note ?? string.Empty)
    { }
}