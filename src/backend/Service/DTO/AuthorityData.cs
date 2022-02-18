using Model.Tables;

namespace Service.DTO;

/// <summary>権限DTO</summary>
public record AuthorityData(string AuthorityId, string AuthorityName)
{
    /// <summary>コンストラクタ</summary>
    public AuthorityData(Authority authority) : this(authority.AuthorityID.ToString(), authority.AuthorityName) { }
}