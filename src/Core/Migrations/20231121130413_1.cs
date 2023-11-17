using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobDate",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsInativo",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EventTitle",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsInativo",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    JobCatergory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteJobs",
                columns: table => new
                {
                    UserFavoriteJobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserInfoID = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteJobs", x => x.UserFavoriteJobID);
                    table.ForeignKey(
                        name: "FK_UserFavoriteJobs_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteJobs_Users_UserInfoID",
                        column: x => x.UserInfoID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteJobs_JobID",
                table: "UserFavoriteJobs",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteJobs_UserInfoID",
                table: "UserFavoriteJobs",
                column: "UserInfoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UserFavoriteJobs");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsInativo",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "EventTitle",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "IsInativo",
                table: "Events");

            migrationBuilder.AddColumn<DateTime>(
                name: "JobDate",
                table: "Jobs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
