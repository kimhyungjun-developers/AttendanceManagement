using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Tables;

namespace Model.DataContext;

/// <summary>データコンテキストの基底クラス</summary>
public abstract class DataContextBase : DbContext, IDataContext
{
    /// <summary>ユーザー</summary>
    public DbSet<User> Users => Set<User>();

    /// <summary>ユーザー認証</summary>
    public DbSet<Authentication> Authentications => Set<Authentication>();

    /// <summary>権限</summary>
    public DbSet<Authority> Authorities => Set<Authority>();

    /// <summary>グループ</summary>
    public DbSet<Group> Groups => Set<Group>();

    /// <summary>承認フロー</summary>
    public DbSet<ApprovalFlow> ApprovalFlows => Set<ApprovalFlow>();

    /// <summary>承認履歴</summary>
    public DbSet<ApprovalHistory> ApprovalHistories => Set<ApprovalHistory>();

    /// <summary>勤怠月間管理</summary>
    public DbSet<AttendanceMonth> AttendanceMonths => Set<AttendanceMonth>();

    /// <summary>勤怠詳細</summary>
    public DbSet<AttendanceDetail> AttendanceDetails => Set<AttendanceDetail>();

    /// <summary>勤務区分</summary>
    public DbSet<WorkDivision> WorkDivisions => Set<WorkDivision>();

    /// <summary>休日</summary>
    public DbSet<Holiday> Holidays => Set<Holiday>();

    /// <summary>トランザクション</summary>
    private IDbContextTransaction? transaction;

    /// <inheritdoc/>
    public async Task BeginTransactionAsync()
    {
        if (transaction != null) throw new InvalidOperationException("トランザクションが既に開始しています");
        transaction = await Database.BeginTransactionAsync();
    }

    /// <inheritdoc/>
    public async Task CommitAsync()
    {
        if (transaction == null) throw new InvalidOperationException("トランザクションが開始されていません");
        await transaction.CommitAsync();
        transaction = null;
    }

    /// <summary>モデル生成時処理</summary>
    /// <param name="modelBuilder">モデルビルダー</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SetPrimary(modelBuilder);
        SetCascade(modelBuilder);
        SetUnique(modelBuilder);
        SetSeed(modelBuilder);
    }

    /// <summary>型変換処理</summary>
    /// <param name="builder">モデルコンフィグレーションビルダー</param>
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");

        builder.Properties<DateOnly?>()
            .HaveConversion<NullableDateOnlyConverter>()
            .HaveColumnType("date");

        builder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>();

        builder.Properties<TimeOnly?>()
            .HaveConversion<NullableTimeOnlyConverter>();
    }

    /// <summary>主キーの設定を行う</summary>
    /// <param name="modelBuilder">モデルビルダー</param>
    private static void SetPrimary(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApprovalFlow>().HasKey(x => x.ApprovalFlowID);
        modelBuilder.Entity<ApprovalHistory>().HasKey(x => x.ApprovalHistoryID);
        modelBuilder.Entity<AttendanceDetail>().HasKey(x => x.AttendanceDetailID);
        modelBuilder.Entity<AttendanceMonth>().HasKey(x => x.AttendanceMonthID);
        modelBuilder.Entity<Authentication>().HasOne(x => x.User).WithOne(x => x.Authentication).HasForeignKey<Authentication>(x => x.UserID);
        modelBuilder.Entity<Authority>().HasKey(x => x.AuthorityID);
        modelBuilder.Entity<Group>().HasKey(x => x.GroupID);
        modelBuilder.Entity<Holiday>().HasKey(x => x.HolidayID);
        modelBuilder.Entity<User>().HasKey(x => x.UserID);
        modelBuilder.Entity<WorkDivision>().HasKey(x => x.WorkDivisionID);
    }

    /// <summary>一意列の設定を行う</summary>
    /// <param name="modelBuilder">モデルビルダー</param>
    private static void SetUnique(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasIndex(x => x.EmployeeNumber).IsUnique();
        modelBuilder.Entity<User>().HasIndex(x => x.MailAddress).IsUnique();
    }

    /// <summary>カスケード設定を行う</summary>
    /// <param name="modelBuilder">モデルビルダー</param>
    private static void SetCascade(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasOne(x => x.Authentication).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<User>().HasOne(x => x.Authority).WithMany(x => x.User).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<User>().HasOne(x => x.Group).WithMany(x => x.User).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<User>().HasMany(x => x.AttendanceMonth).WithOne(x => x.User).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<User>().HasMany(x => x.ApprovalHistory).WithOne(x => x.Approver).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<User>().HasMany(x => x.ApprovalFlow).WithOne(x => x.Approver).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ApprovalFlow>().HasOne(x => x.Group).WithMany(x => x.ApprovalFlow).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<ApprovalHistory>().HasOne(x => x.AttendanceMonth).WithMany(x => x.ApprovalHistory).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<AttendanceDetail>().HasOne(x => x.AttendanceMonth).WithMany(x => x.AttendanceDetail).OnDelete(DeleteBehavior.Cascade);
    }

    /// <summary>シードデータを投入する</summary>
    /// <param name="modelBuilder">モデルビルダー</param>
    private static void SetSeed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Authority>().HasData(
            new() { AuthorityID = Enum.Authorities.General, AuthorityName = "一般" },
            new() { AuthorityID = Enum.Authorities.Administrator, AuthorityName = "管理者" });

        modelBuilder.Entity<WorkDivision>().HasData(
            new() { WorkDivisionID = Enum.WorkDivisions.RegularWork, WorkDivisionName = "通常勤務", NeedInputTime = true, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.PaidHoliday, WorkDivisionName = "有給休暇", NeedInputTime = false, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.HalfHoliday, WorkDivisionName = "半休", NeedInputTime = true, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.Absence, WorkDivisionName = "欠勤", NeedInputTime = false, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.HolidayWork, WorkDivisionName = "休日出勤", NeedInputTime = true, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.Substituteholiday, WorkDivisionName = "代休", NeedInputTime = false, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.SummerVacation, WorkDivisionName = "夏期休暇", NeedInputTime = false, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.NewYearHoliday, WorkDivisionName = "年末年始", NeedInputTime = false, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.MedicalCheck, WorkDivisionName = "健康診断", NeedInputTime = true, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.AfterNight, WorkDivisionName = "夜勤明け", NeedInputTime = true, Deleted = false },
            new() { WorkDivisionID = Enum.WorkDivisions.ClosedHoliday, WorkDivisionName = "休業", NeedInputTime = false, Deleted = false });

        // TODO:リリース時に消す
        modelBuilder.Entity<Authentication>().HasData(
            new() { UserID = "1", Password = "JpIVUgauxYdYTieOcICaf58RV51021q/d0piw2RNIVY=", PasswordSalt = "/CiBj6zceZn63k3rUF90fCW5Jg1knd9TCwarIgHB6gQ=" },
            new() { UserID = "2", Password = "JpIVUgauxYdYTieOcICaf58RV51021q/d0piw2RNIVY=", PasswordSalt = "/CiBj6zceZn63k3rUF90fCW5Jg1knd9TCwarIgHB6gQ=" });
        modelBuilder.Entity<User>().HasData(
            new() { UserID = "1", EmployeeNumber = "1", GroupID = "1", AuthorityID = Enum.Authorities.General, LastName = "山田", FirstName = "太郎", MailAddress = "general@example.com" },
            new() { UserID = "2", EmployeeNumber = "2", GroupID = "1", AuthorityID = Enum.Authorities.Administrator, LastName = "山田", FirstName = "太郎", MailAddress = "admin@example.com" });
        modelBuilder.Entity<Group>().HasData(new Group() { GroupID = "1", GroupName = "グループ名" });
    }

    /// <summary>DateOnly型のコンバーター</summary>
    private class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
    {
        public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
        { }
    }

    /// <summary>NullableDateOnly型のコンバーター</summary>
    private class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
    {
        public NullableDateOnlyConverter() : base(
            dateOnly => dateOnly == null
                ? null
                : new DateTime?(dateOnly.Value.ToDateTime(TimeOnly.MinValue)),
            dateTime => dateTime == null
                ? null
                : new DateOnly?(DateOnly.FromDateTime(dateTime.Value)))
        { }
    }

    /// <summary>TimeOnly型のコンバーター</summary>
    private class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
    {
        public TimeOnlyConverter() : base(
            timeOnly => timeOnly.ToTimeSpan(),
            timeSpan => TimeOnly.FromTimeSpan(timeSpan))
        { }
    }

    /// <summary>NullableTimeOnly型のコンバーター</summary>
    private class NullableTimeOnlyConverter : ValueConverter<TimeOnly?, TimeSpan?>
    {
        public NullableTimeOnlyConverter() : base(
            timeOnly => timeOnly == null
                ? null
                : timeOnly.Value.ToTimeSpan(),
            timeSpan => timeSpan == null
                ? null
                : TimeOnly.FromTimeSpan(timeSpan.Value))
        { }
    }
}