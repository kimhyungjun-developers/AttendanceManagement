using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Infrastructures;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest.DataServices;

public class AuthenticationTest : TestBase
{
    public AuthenticationTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task ログイン判定で成功すること()
    {
        var group = TestDataGenerator.GetGroupTestDatas(1).First();
        var user = TestDataGenerator.GetUserTestDatas(2, group.GroupID).First();
        var authentication = TestDataGenerator.GetAuthenticationTestData(user.UserID);

        await DataContext.Groups.AddAsync(group);
        await DataContext.SaveChangesAsync();
        await DataContext.Users.AddAsync(user);
        await DataContext.SaveChangesAsync();
        await DataContext.Authentications.AddAsync(authentication);
        await DataContext.SaveChangesAsync();

        (await DataService.CanLoginAsync(user.UserID, "P@ssw0rd!")).Should().BeTrue();
    }

    [Fact]
    public async Task 存在しないユーザーIDの場合ログイン判定で失敗すること()
    {
        var userID = Guid.NewGuid().ToString();
        Func<Task> action = () => DataService.CanLoginAsync(userID, "Password");
        await action.Should().ThrowAsync<ArgumentException>().WithMessage(MessageGenerator.NotExistUserByUserIDMessage(userID));
    }

    [Fact]
    public async Task パスワードが一致しない場合ログイン判定で失敗すること()
    {
        var group = TestDataGenerator.GetGroupTestDatas(1).First();
        var user = TestDataGenerator.GetUserTestDatas(2, group.GroupID).First();
        var authentication = TestDataGenerator.GetAuthenticationTestData(user.UserID);

        await DataContext.Groups.AddAsync(group);
        await DataContext.SaveChangesAsync();
        await DataContext.Users.AddAsync(user);
        await DataContext.SaveChangesAsync();
        await DataContext.Authentications.AddAsync(authentication);
        await DataContext.SaveChangesAsync();

        Func<Task> action = () => DataService.CanLoginAsync(user.UserID, "Password");
        await action.Should().ThrowAsync<ArgumentException>().WithMessage(MessageGenerator.IncorrectPasswordMessage());
    }
}