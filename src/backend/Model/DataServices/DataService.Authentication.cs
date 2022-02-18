using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Model.DataServices;

///<inheritdoc/>
public partial class DataService
{
    /// <summary>ソルトサイズ</summary>
    private const int SaltSize = 32;

    /// <summary>ハッシュサイズ</summary>
    private const int HashSize = 32;

    /// <summary>ストレッチング回数</summary>
    private const int Iteration = 10000;

    public async Task<bool> CanLoginAsync(string userID, string password)
    {
        if (!await IsExistUserAsync(userID))
            throw new ArgumentException(messageGenerator.NotExistUserByUserIDMessage(userID));

        var authorization = await dataContext.Authentications.SingleAsync(x => x.UserID == userID);
        var passwordSalt = authorization.PasswordSalt;
        var passwordHash = PasswordHashByte(password, passwordSalt);

        if (authorization.Password != passwordHash)
            throw new ArgumentException(messageGenerator.IncorrectPasswordMessage());

        return true;
    }

    /// <summary>ハッシュ値を生成 </summary>
    private static byte[] CreatePBKDF2Hash(string password, byte[] salt, int size, int iteration)
    {
        using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iteration);
        return rfc2898DeriveBytes.GetBytes(size);
    }

    /// <summary>ハッシュ化パスワードとソルトの生成</summary>
    private static (string hashPassword, string salt) PasswordHashText(string password)
    {
        var saltBytes = RandomNumberGenerator.GetBytes(SaltSize);

        var hashBytes = CreatePBKDF2Hash(password, saltBytes, HashSize, Iteration);
        var hashText = Convert.ToBase64String(hashBytes);
        var saltText = Convert.ToBase64String(saltBytes);

        return (hashText, saltText);
    }

    /// <summary>パスワードのハッシュ化</summary>
    private static string PasswordHashByte(string password, string passwordSalt)
    {
        var saltBytes = Convert.FromBase64String(passwordSalt);
        var hashBytes = CreatePBKDF2Hash(password, saltBytes, HashSize, Iteration);

        return Convert.ToBase64String(hashBytes);
    }
}