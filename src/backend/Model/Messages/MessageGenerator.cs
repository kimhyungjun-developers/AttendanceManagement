namespace Model.Messages;

/// <summary>メッセージ生成</summary>
public class MessageGenerator : IMessageGenerator
{
    public string CannotLoginMessage() =>
        "ログインに失敗しました。";

    public string IncorrectPasswordMessage() =>
        "パスワードが正しくありません。";

    public string NotExistUserByMailMessage(string email) =>
        $"メールアドレスが正しくありません。[{email}]";

    public string NotExistUserByUserIDMessage(string userId) =>
        $"ユーザーIDが正しくありません。[{userId}]";
}