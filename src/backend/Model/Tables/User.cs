using Model.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Tables;

/// <summary>ユーザーテーブル</summary>
public class User : TableBase
{
    /// <summary>ユーザーID</summary>
    [Key]
    public string UserID { get; init; } = string.Empty;

    /// <summary>グループID</summary>
    [ForeignKey(nameof(Group))]
    public string GroupID { get; set; } = string.Empty;

    /// <summary>グループ</summary>
    public virtual Group Group { get; set; } = null!;

    /// <summary>権限ID</summary>
    [ForeignKey(nameof(Authority))]
    public Authorities AuthorityID { get; set; }

    /// <summary>権限</summary>
    public virtual Authority Authority { get; set; } = null!;

    /// <summary>社員番号</summary>
    public string EmployeeNumber { get; init; } = string.Empty;

    /// <summary>メールアドレス</summary>
    public string MailAddress { get; init; } = string.Empty;

    /// <summary>姓</summary>
    public string LastName { get; set; } = string.Empty;

    /// <summary>名</summary>
    public string FirstName { get; set; } = string.Empty;

    /// <summary>姓（フリガナ）</summary>
    public string LastNameFurigana { get; set; } = string.Empty;

    /// <summary>名（フリガナ）</summary>
    public string FirstNameFurigana { get; set; } = string.Empty;

    /// <summary>所定勤務開始時間</summary>
    public TimeOnly? DefaultStartTime { get; set; }

    /// <summary>所定勤務終了時間</summary>
    public TimeOnly? DefaultEndTime { get; set; }

    /// <summary>所定休憩時間</summary>
    public TimeOnly? DefaultRestTime { get; set; }

    /// <summary>削除フラグ</summary>
    public bool Deleted { get; set; }

    /// <summary>ユーザー認証</summary>
    public virtual Authentication Authentication { get; set; } = null!;

    /// <summary>承認フローを識別するためのキー情報</summary>
    public virtual ICollection<ApprovalFlow> ApprovalFlow { get; set; } = null!;

    /// <summary>承認フローを識別するためのキー情報</summary>
    public virtual ICollection<ApprovalHistory> ApprovalHistory { get; set; } = null!;

    /// <summary>勤怠月間を識別するためのキー情報</summary>
    public virtual ICollection<AttendanceMonth> AttendanceMonth { get; set; } = null!;
}