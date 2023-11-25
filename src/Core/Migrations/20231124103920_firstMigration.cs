using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
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
                    IsInativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventID);
                });

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
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    JobAddress = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsInativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                    table.ForeignKey(
                        name: "FK_Jobs_Categories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId");

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
                name: "Events");

            migrationBuilder.DropTable(
                name: "UserFavoriteJobs");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
