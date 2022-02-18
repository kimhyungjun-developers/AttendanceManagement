using Model.DataServices;
using Model.Messages;

namespace Service.Authentications;

/// <summary>ログイン検証サービス</summary>
public class LoginChecker
{
    /// <summary>データサービス</summary>
    private readonly IDataService dataService;

    /// <summary>メッセージ生成</summary>
    private readonly IMessageGenerator messageGenerator;

    /// <summary>コンストラクタ</summary>
    public LoginChecker(IDataService dataService, IMessageGenerator messageGenerator)
    {
        this.dataService = dataService;
        this.messageGenerator = messageGenerator;
    }

    /// <summary>ログイン検証</summary>
    public async Task<string> CheckAsync(string mailAddress, string password)
    {
        var user = await dataService.GetUserByMailAddressAsync(mailAddress);
        if (user is null)
            throw new ArgumentException(messageGenerator.NotExistUserByMailMessage(mailAddress));
        if (!await dataService.CanLoginAsync(user.UserID, password))
            throw new ArgumentException(messageGenerator.CannotLoginMessage());
        return user.UserID;
    }
}