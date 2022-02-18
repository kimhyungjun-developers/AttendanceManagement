using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authorities",
                columns: table => new
                {
                    AuthorityID = table.Column<int>(type: "int", nullable: false),
                    AuthorityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authorities", x => x.AuthorityID);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.GroupID);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    HolidayID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HolidayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.HolidayID);
                });

            migrationBuilder.CreateTable(
                name: "WorkDivisions",
                columns: table => new
                {
                    WorkDivisionID = table.Column<int>(type: "int", nullable: false),
                    WorkDivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeedInputTime = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkDivisions", x => x.WorkDivisionID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorityID = table.Column<int>(type: "int", nullable: false),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MailAddress = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastNameFurigana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstNameFurigana = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultStartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DefaultEndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    DefaultRestTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Authorities_AuthorityID",
                        column: x => x.AuthorityID,
                        principalTable: "Authorities",
                        principalColumn: "AuthorityID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalFlows",
                columns: table => new
                {
                    ApprovalFlowID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApproverID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApprovalOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalFlows", x => x.ApprovalFlowID);
                    table.ForeignKey(
                        name: "FK_ApprovalFlows_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalFlows_Users_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceMonths",
                columns: table => new
                {
                    AttendanceMonthID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceMonths", x => x.AttendanceMonthID);
                    table.ForeignKey(
                        name: "FK_AttendanceMonths_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Authentications",
                columns: table => new
                {
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentications", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Authentications_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalHistories",
                columns: table => new
                {
                    ApprovalHistoryID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttendanceMonthID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApproverID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalHistories", x => x.ApprovalHistoryID);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_AttendanceMonths_AttendanceMonthID",
                        column: x => x.AttendanceMonthID,
                        principalTable: "AttendanceMonths",
                        principalColumn: "AttendanceMonthID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApprovalHistories_Users_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceDetails",
                columns: table => new
                {
                    AttendanceDetailID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttendanceMonthID1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WorkDivisionID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RestTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ActualTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    OverTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    MidnightTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    WeekdayDivision = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceDetails", x => x.AttendanceDetailID);
                    table.ForeignKey(
                        name: "FK_AttendanceDetails_AttendanceMonths_AttendanceMonthID1",
                        column: x => x.AttendanceMonthID1,
                        principalTable: "AttendanceMonths",
                        principalColumn: "AttendanceMonthID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authorities",
                columns: new[] { "AuthorityID", "AuthorityName", "CreateDate", "CreateProgram", "CreateUser", "UpdateDate", "UpdateProgram", "UpdateUser" },
                values: new object[,]
                {
                    { 1, "一般", null, "", "", null, "", "" },
                    { 2, "管理者", null, "", "", null, "", "" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "CreateDate", "CreateProgram", "CreateUser", "GroupName", "UpdateDate", "UpdateProgram", "UpdateUser" },
                values: new object[] { "1", null, "", "", "グループ名", null, "", "" });

            migrationBuilder.InsertData(
                table: "WorkDivisions",
                columns: new[] { "WorkDivisionID", "CreateDate", "CreateProgram", "CreateUser", "Deleted", "NeedInputTime", "UpdateDate", "UpdateProgram", "UpdateUser", "WorkDivisionName" },
                values: new object[,]
                {
                    { 1, null, "", "", false, true, null, "", "", "通常勤務" },
                    { 2, null, "", "", false, false, null, "", "", "有給休暇" },
                    { 3, null, "", "", false, true, null, "", "", "半休" },
                    { 4, null, "", "", false, false, null, "", "", "欠勤" },
                    { 5, null, "", "", false, true, null, "", "", "休日出勤" },
                    { 6, null, "", "", false, false, null, "", "", "代休" },
                    { 7, null, "", "", false, false, null, "", "", "夏期休暇" },
                    { 8, null, "", "", false, false, null, "", "", "年末年始" },
                    { 9, null, "", "", false, true, null, "", "", "健康診断" },
                    { 10, null, "", "", false, true, null, "", "", "夜勤明け" },
                    { 11, null, "", "", false, false, null, "", "", "休業" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AuthorityID", "CreateDate", "CreateProgram", "CreateUser", "DefaultEndTime", "DefaultRestTime", "DefaultStartTime", "Deleted", "EmployeeNumber", "FirstName", "FirstNameFurigana", "GroupID", "LastName", "LastNameFurigana", "MailAddress", "UpdateDate", "UpdateProgram", "UpdateUser" },
                values: new object[] { "1", 1, null, "", "", null, null, null, false, "1", "太郎", "", "1", "山田", "", "general@example.com", null, "", "" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AuthorityID", "CreateDate", "CreateProgram", "CreateUser", "DefaultEndTime", "DefaultRestTime", "DefaultStartTime", "Deleted", "EmployeeNumber", "FirstName", "FirstNameFurigana", "GroupID", "LastName", "LastNameFurigana", "MailAddress", "UpdateDate", "UpdateProgram", "UpdateUser" },
                values: new object[] { "2", 2, null, "", "", null, null, null, false, "2", "太郎", "", "1", "山田", "", "admin@example.com", null, "", "" });

            migrationBuilder.InsertData(
                table: "Authentications",
                columns: new[] { "UserID", "CreateDate", "CreateProgram", "CreateUser", "Password", "PasswordSalt", "UpdateDate", "UpdateProgram", "UpdateUser" },
                values: new object[] { "1", null, "", "", "JpIVUgauxYdYTieOcICaf58RV51021q/d0piw2RNIVY=", "/CiBj6zceZn63k3rUF90fCW5Jg1knd9TCwarIgHB6gQ=", null, "", "" });

            migrationBuilder.InsertData(
                table: "Authentications",
                columns: new[] { "UserID", "CreateDate", "CreateProgram", "CreateUser", "Password", "PasswordSalt", "UpdateDate", "UpdateProgram", "UpdateUser" },
                values: new object[] { "2", null, "", "", "JpIVUgauxYdYTieOcICaf58RV51021q/d0piw2RNIVY=", "/CiBj6zceZn63k3rUF90fCW5Jg1knd9TCwarIgHB6gQ=", null, "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalFlows_ApproverID",
                table: "ApprovalFlows",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalFlows_GroupID",
                table: "ApprovalFlows",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_ApproverID",
                table: "ApprovalHistories",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalHistories_AttendanceMonthID",
                table: "ApprovalHistories",
                column: "AttendanceMonthID");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDetails_AttendanceMonthID1",
                table: "AttendanceDetails",
                column: "AttendanceMonthID1");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceMonths_UserID",
                table: "AttendanceMonths",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AuthorityID",
                table: "Users",
                column: "AuthorityID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EmployeeNumber",
                table: "Users",
                column: "EmployeeNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupID",
                table: "Users",
                column: "GroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MailAddress",
                table: "Users",
                column: "MailAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalFlows");

            migrationBuilder.DropTable(
                name: "ApprovalHistories");

            migrationBuilder.DropTable(
                name: "AttendanceDetails");

            migrationBuilder.DropTable(
                name: "Authentications");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "WorkDivisions");

            migrationBuilder.DropTable(
                name: "AttendanceMonths");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Authorities");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
