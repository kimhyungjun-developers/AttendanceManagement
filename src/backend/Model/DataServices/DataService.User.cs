using Microsoft.EntityFrameworkCore;
using Model.Tables;

namespace Model.DataServices;

///<inheritdoc/>
public partial class DataService
{
    public async Task<bool> IsExistUserAsync(string userID) =>
        await dataContext.Users.AnyAsync(x => x.UserID == userID);

    public Task<User?> GetUserByMailAddressAsync(string mailAddress) =>
        dataContext.Users.SingleOrDefaultAsync(x => x.MailAddress == mailAddress);

    public Task<User?> GetUserByUserIDAsync(string userID) =>
        dataContext.Users.SingleOrDefaultAsync(x => x.UserID == userID);
}