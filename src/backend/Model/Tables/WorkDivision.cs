using Model.Enum;
using System.ComponentModel.DataAnnotations;

namespace Model.Tables;

/// <summary>勤務区分テーブル/summary>
public class WorkDivision : TableBase
{
    /// <summary>勤務区分ID</summary>
    [Key]
    public WorkDivisions WorkDivisionID { get; init; }

    /// <summary>勤務区分名</summary>
    public string WorkDivisionName { get; set; } = string.Empty;

    /// <summary>要時刻入力</summary>
    public bool NeedInputTime { get; set; }

    /// <summary>削除フラグ</summary>
    public bool Deleted { get; set; }
}