using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class testeyuri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhone = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserInfoId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    EventAddress = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                    table.ForeignKey(
                        name: "FK_Events_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    JobCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInativo = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteEvents",
                columns: table => new
                {
                    UserFavoriteEventID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserInfoID = table.Column<int>(type: "int", nullable: false),
                    EventID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteEvents", x => x.UserFavoriteEventID);
                    table.ForeignKey(
                        name: "FK_UserFavoriteEvents_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteEvents_Users_UserInfoID",
                        column: x => x.UserInfoID,
                        principalTable: "Users",
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "UserInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedByUserId",
                table: "Events",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CreatedByUserId",
                table: "Jobs",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteEvents_EventID",
                table: "UserFavoriteEvents",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteEvents_UserInfoID",
                table: "UserFavoriteEvents",
                column: "UserInfoID");

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
                name: "UserFavoriteEvents");

            migrationBuilder.DropTable(
                name: "UserFavoriteJobs");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
