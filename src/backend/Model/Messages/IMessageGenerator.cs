namespace Model.Messages;

/// <summary>メッセージ生成</summary>
public interface IMessageGenerator
{
    /// <summary>ログイン失敗のメッセージ</summary>
    string CannotLoginMessage();

    /// <summary>パスワード不一致のメッセージ</summary>
    string IncorrectPasswordMessage();

    /// <summary>メールアドレスの対象ユーザーが存在しないメッセージ</summary>
    string NotExistUserByMailMessage(string email);

    /// <summary>ユーザーIDの対象ユーザーが存在しないメッセージ</summary>
    string NotExistUserByUserIDMessage(string userId);
}