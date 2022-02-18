using Model.Tables;

namespace Service.DTO;

/// <summary>休日DTO</summary>
public record HolidayData(string HolidayId, string HolidayName, string Date)
{
    /// <summary>コンストラクタ</summary>
    public HolidayData(Holiday holiday) : this(holiday.HolidayID, holiday.HolidayName, holiday.Date.ToString()) { }
}