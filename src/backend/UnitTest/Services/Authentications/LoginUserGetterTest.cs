using FluentAssertions;
using Model.DataServices;
using Model.Tables;
using Moq;
using Service.Authentications;
using Service.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Infrastructures;
using Xunit;
using Xunit.Abstractions;

namespace UnitTest.Services.Authentications;

public class LoginUserGetterTest : TestBase
{
    public LoginUserGetterTest(ITestOutputHelper output) : base(output)
    {
    }

    [Fact]
    public async Task ユーザー取得に成功すること()
    {
        var dataserviceMock = new Mock<IDataService>();

        var user = TestDataGenerator.GetUserTestDatas(1).First();
        dataserviceMock.Setup(x => x.GetUserByUserIDAsync(user.UserID)).ReturnsAsync(user);

        (await new LoginUserGetter(dataserviceMock.Object, MessageGenerator).GetAsync(user.UserID))
            .Should().BeEquivalentTo(new UserData(user));
    }

    [Fact]
    public async Task ユーザーIDが誤っている場合に例外になること()
    {
        var dataserviceMock = new Mock<IDataService>();

        dataserviceMock.Setup(x => x.GetUserByUserIDAsync(It.IsAny<string>())).ReturnsAsync((User?)null);

        var userID = Guid.NewGuid().ToString();
        await new LoginUserGetter(dataserviceMock.Object, MessageGenerator).Invoking(x => x.GetAsync(userID))
            .Should().ThrowAsync<ArgumentException>().WithMessage(MessageGenerator.NotExistUserByUserIDMessage(userID));
    }
}