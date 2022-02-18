namespace Model.Enum;

/// <summary>勤怠種別</summary>
public enum WorkDivisions
{
    /// <summary>通常勤務</summary>
    RegularWork = 1,

    /// <summary>有休</summary>
    PaidHoliday,

    /// <summary>半休</summary>
    HalfHoliday,

    /// <summary>欠勤</summary>
    Absence,

    /// <summary>休日出勤</summary>
    HolidayWork,

    /// <summary>代休</summary>
    Substituteholiday,

    /// <summary>夏季休暇</summary>
    SummerVacation,

    /// <summary>年末年始</summary>
    NewYearHoliday,

    /// <summary>健康診断</summary>
    MedicalCheck,

    /// <summary>夜勤明け</summary>
    AfterNight,

    /// <summary>休業</summary>
    ClosedHoliday
}