using Model.Tables;

namespace Service.DTO;

/// <summary>グループDTO</summary>
public record GroupData(string GroupId, string GroupName)
{
    /// <summary>コンストラクタ</summary>
    public GroupData(Group group) : this(group.GroupID, group.GroupName) { }
}