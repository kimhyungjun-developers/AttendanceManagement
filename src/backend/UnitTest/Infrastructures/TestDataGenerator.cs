using AutoFixture;
using Model.Tables;
using System;
using System.Linq;

namespace UnitTest.Infrastructures;

/// <summary>テストデータ自動生成クラス</summary>
public static class TestDataGenerator
{
    public static User[] GetUserTestDatas(int count, string? groupID = null)
    {
        var fixture = new Fixture();
        return fixture
            .Build<User>()
            .Without(x => x.Authentication)
            .Without(x => x.Authority)
            .Without(x => x.Group)
            .Without(x => x.ApprovalFlow)
            .Without(x => x.ApprovalHistory)
            .Without(x => x.AttendanceMonth)
            .With(x => x.GroupID, () => groupID ?? Guid.NewGuid().ToString())
            .CreateMany(count).ToArray();
    }

    public static Authentication GetAuthenticationTestData(string userID)
    {
        var fixture = new Fixture();
        return fixture
            .Build<Authentication>()
            .Without(x => x.User)
            .With(x => x.UserID, () => userID)
            .With(x => x.Password, () => "JpIVUgauxYdYTieOcICaf58RV51021q/d0piw2RNIVY=")
            .With(x => x.PasswordSalt, () => "/CiBj6zceZn63k3rUF90fCW5Jg1knd9TCwarIgHB6gQ=")
            .Create();
        // 作業メモ：パスワードは「P@ssw0rd!」で認証が通ります。
    }

    public static Group[] GetGroupTestDatas(int count)
    {
        var fixture = new Fixture();
        return fixture
            .Build<Group>()
            .Without(x => x.ApprovalFlow)
            .Without(x => x.User)
            .CreateMany(count).ToArray();
    }
}