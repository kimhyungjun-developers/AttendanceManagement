using Model.Tables;

namespace Service.DTO;

/// <summary>承認履歴DTO</summary>
public record ApprovalHistoryData(
    string ApprovalHistoryId,
    string AttendanceMonthId,
    string ProcessUserId,
    string ProcessDateTime,
    string Comment)
{
    /// <summary>コンストラクタ</summary>
    public ApprovalHistoryData(ApprovalHistory approvalHistory) : this(
        approvalHistory.ApprovalHistoryID,
        approvalHistory.AttendanceMonthID,
        approvalHistory.ApproverID,
        approvalHistory.Date.ToString(),
        approvalHistory.Comment ?? string.Empty)
    { }
}