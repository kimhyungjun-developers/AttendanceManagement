using FluentAssertions;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Infrastructures;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest.DataServices;

public class UserTest : TestBase
{
    public UserTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task ユーザーIDからユーザーの存在確認に成功すること()
    {
        var group = TestDataGenerator.GetGroupTestDatas(1).First();
        var users = TestDataGenerator.GetUserTestDatas(2, group.GroupID);

        await DataContext.Groups.AddAsync(group);
        await DataContext.SaveChangesAsync();
        await DataContext.Users.AddAsync(users[0]);
        await DataContext.SaveChangesAsync();

        (await DataService.IsExistUserAsync(users[0].UserID)).Should().BeTrue();
        (await DataService.IsExistUserAsync(users[1].UserID)).Should().BeFalse();
    }

    [Fact]
    public async Task メールアドレスからユーザーの取得に成功すること()
    {
        var group = TestDataGenerator.GetGroupTestDatas(1).First();
        var user = TestDataGenerator.GetUserTestDatas(1, group.GroupID).First();

        await DataContext.Groups.AddAsync(group);
        await DataContext.SaveChangesAsync();
        await DataContext.Users.AddAsync(user);
        await DataContext.SaveChangesAsync();

        (await DataService.GetUserByMailAddressAsync(user.MailAddress)).Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task 登録されてないメールアドレスの場合はNullが返却されること()
    {
        (await DataService.GetUserByMailAddressAsync("test@example.com")).Should().BeNull();
    }

    [Fact]
    public async Task ユーザーIDからユーザーの取得に成功すること()
    {
        var group = TestDataGenerator.GetGroupTestDatas(1).First();
        var user = TestDataGenerator.GetUserTestDatas(1, group.GroupID).First();

        await DataContext.Groups.AddAsync(group);
        await DataContext.SaveChangesAsync();
        await DataContext.Users.AddAsync(user);
        await DataContext.SaveChangesAsync();

        (await DataService.GetUserByUserIDAsync(user.UserID)).Should().BeEquivalentTo(user);
    }

    [Fact]
    public async Task 登録されてないユーザーIDの場合はNullが返却されること()
    {
        (await DataService.GetUserByUserIDAsync(Guid.NewGuid().ToString())).Should().BeNull();
    }
}