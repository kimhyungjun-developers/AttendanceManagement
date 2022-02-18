using Model.DataServices;
using Model.Messages;
using Service.DTO;

namespace Service.Authentications;

/// <summary>ログインユーザー取得サービス</summary>
public class LoginUserGetter
{
    /// <summary>データサービス</summary>
    private readonly IDataService dataService;

    /// <summary>メッセージ生成</summary>
    private readonly IMessageGenerator messageGenerator;

    /// <summary>コンストラクタ</summary>
    public LoginUserGetter(IDataService dataService, IMessageGenerator messageGenerator)
    {
        this.dataService = dataService;
        this.messageGenerator = messageGenerator;
    }

    /// <summary>ログインユーザー取得処理</summary>
    public async Task<UserData> GetAsync(string userID)
    {
        var user = await dataService.GetUserByUserIDAsync(userID);
        if (user is null)
            throw new ArgumentException(messageGenerator.NotExistUserByUserIDMessage(userID));
        return new UserData(user);
    }
}