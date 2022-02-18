using Model.Tables;

namespace Service.DTO;

/// <summary>勤務区分DTO</summary>
public record WorkDivisionData(string WorkDivisionId, string WorkDivisionName, bool RequiedInputTime)
{
    /// <summary>コンストラクタ</summary>
    public WorkDivisionData(WorkDivision workDivision) :
        this(workDivision.WorkDivisionID.ToString(), workDivision.WorkDivisionName, workDivision.NeedInputTime)
    { }
}