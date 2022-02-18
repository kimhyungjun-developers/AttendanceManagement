using System.ComponentModel.DataAnnotations;

namespace Model.Tables;

/// <summary>休日テーブル</summary>
public class Holiday : TableBase
{
    /// <summary>休日ID</summary>
    [Key]
    public string HolidayID { get; init; } = string.Empty;

    /// <summary>休日名</summary>
    public string HolidayName { get; set; } = string.Empty;

    /// <summary>日付</summary>
    public DateOnly Date { get; set; }
}