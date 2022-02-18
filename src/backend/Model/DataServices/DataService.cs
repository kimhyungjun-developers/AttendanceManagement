using Microsoft.EntityFrameworkCore;
using Model.DataContext;
using Model.Messages;
using Model.Tables;

namespace Model.DataServices;

public sealed partial class DataService : IDataService
{
    /// <summary>データコンテキスト</summary>
    private readonly IDataContext dataContext;

    /// <summary>メッセージ生成</summary>
    private readonly IMessageGenerator messageGenerator;

    /// <summary>コンストラクタ</summary>
    /// <param name="dataContext">データコンテキスト</param>
    /// <param name="messageGenerator">メッセージ生成</param>
    public DataService(IDataContext dataContext, IMessageGenerator messageGenerator)
    {
        this.dataContext = dataContext;
        this.messageGenerator = messageGenerator;
    }

    /// <summary>オブジェクトを破棄する</summary>
    public void Dispose() => dataContext.Dispose();

    /// <summary>オブジェクトを破棄する</summary>
    public ValueTask DisposeAsync() => dataContext.DisposeAsync();

    /// <inheritdoc/>
    public int SaveChanges() => dataContext.SaveChanges();

    /// <inheritdoc/>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => dataContext.SaveChangesAsync(cancellationToken);

    /// <inheritdoc/>
    public Task BeginTransactionAsync() => dataContext.BeginTransactionAsync();

    /// <inheritdoc/>
    public Task CommitAsync() => dataContext.CommitAsync();

    /// <summary>オブジェクトをデタッチする</summary>
    private void DetachEntities<T>(IEnumerable<T> targets) where T : class
    {
        foreach (var target in targets) dataContext.Entry(target).State = EntityState.Detached;
    }

    /// <summary>オブジェクト（単体）をデタッチする（単体用）</summary>
    private void DetachEntity<T>(T target) where T : class => dataContext.Entry(target).State = EntityState.Detached;

    /// <summary>作成情報を付与する</summary>
    private async Task SetCreateInformationAsync(TableBase table, string program, string creatorID)
    {
        var publisher = await dataContext.Users.SingleAsync(x => x.UserID == creatorID);
        table.CreateDate = DateTime.Now;
        table.CreateUser = publisher.MailAddress;
        table.CreateProgram = program;
        table.UpdateDate = DateTime.Now;
        table.UpdateUser = publisher.MailAddress;
        table.UpdateProgram = program;
    }

    /// <summary>更新情報を付与する</summary>
    private async Task SetUpdateInformationAsync(TableBase table, string program, string updaterID)
    {
        var updater = await dataContext.Users.SingleAsync(x => x.UserID == updaterID);
        table.UpdateDate = DateTime.Now;
        table.UpdateUser = updater.MailAddress;
        table.UpdateProgram = program;
    }
}