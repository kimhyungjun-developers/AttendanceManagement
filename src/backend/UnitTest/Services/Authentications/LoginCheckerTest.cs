using FluentAssertions;
using Model.DataServices;
using Model.Tables;
using Moq;
using Service.Authentications;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Infrastructures;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest.Services.Authentications;

public class LoginCheckerTest : TestBase
{
    public LoginCheckerTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task ログインに成功すること()
    {
        var dataserviceMock = new Mock<IDataService>();

        var user = TestDataGenerator.GetUserTestDatas(1).First();
        dataserviceMock.Setup(x => x.GetUserByMailAddressAsync(user.MailAddress)).ReturnsAsync(user);
        dataserviceMock.Setup(x => x.CanLoginAsync(user.UserID, "パスワード")).ReturnsAsync(true);

        (await new LoginChecker(dataserviceMock.Object, MessageGenerator).CheckAsync(user.MailAddress, "パスワード"))
            .Should().Be(user.UserID);
    }

    [Fact]
    public async Task メールアドレスが誤っている場合に例外になること()
    {
        var dataserviceMock = new Mock<IDataService>();

        dataserviceMock.Setup(x => x.GetUserByMailAddressAsync(It.IsAny<string>())).ReturnsAsync((User?)null);

        await new LoginChecker(dataserviceMock.Object, MessageGenerator).Invoking(x => x.CheckAsync("test@example.com", "パスワード"))
            .Should().ThrowAsync<ArgumentException>().WithMessage(MessageGenerator.NotExistUserByMailMessage("test@example.com"));
    }

    [Fact]
    public async Task パスワードが誤っている場合に例外になること()
    {
        var dataserviceMock = new Mock<IDataService>();

        var user = TestDataGenerator.GetUserTestDatas(1).First();
        dataserviceMock.Setup(x => x.GetUserByMailAddressAsync(user.MailAddress)).ReturnsAsync(user);
        dataserviceMock.Setup(x => x.CanLoginAsync(user.UserID, "パスワード")).ReturnsAsync(false);

        await new LoginChecker(dataserviceMock.Object, MessageGenerator).Invoking(x => x.CheckAsync(user.MailAddress, "パスワード"))
            .Should().ThrowAsync<ArgumentException>().WithMessage(MessageGenerator.CannotLoginMessage());
    }
}