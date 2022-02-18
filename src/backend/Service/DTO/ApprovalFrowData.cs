using Model.Tables;

namespace Service.DTO;

/// <summary>承認フローDTO</summary>
public record ApprovalFlowData(string ApprovalFlowId, string ApproverId, int ApprovalOrder)
{
    /// <summary>コンストラクタ</summary>
    public ApprovalFlowData(ApprovalFlow approvalFlow) :
        this(approvalFlow.ApprovalFlowID, approvalFlow.ApproverID, approvalFlow.ApprovalOrder)
    { }
}