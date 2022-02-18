using Model.Tables;

namespace Service.DTO;

/// <summary>ユーザーDTO</summary>
public record UserData(
    string UserId,
    string AuthorityId,
    string GroupId,
    string EmployeeNumber,
    string Email,
    string FirstName,
    string LastName,
    string FirstNameFurigana,
    string LastNameFurigana,
    string DefaultStartTime,
    string DefaultEndTime,
    string DefauktRestTime)
{
    /// <summary>コンストラクタ</summary>
    public UserData(User user) : this(
        user.UserID,
        user.AuthorityID.ToString(),
        user.GroupID,
        user.EmployeeNumber,
        user.MailAddress,
        user.FirstName,
        user.LastName,
        user.FirstNameFurigana,
        user.LastNameFurigana,
        user.DefaultStartTime.ToString() ?? string.Empty,
        user.DefaultEndTime.ToString() ?? string.Empty,
        user.DefaultRestTime.ToString() ?? string.Empty)
    { }
}