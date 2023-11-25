using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    public partial class step4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Categories_JobCategoryId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropColumn(
                name: "EventType",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "JobCategoryId",
                table: "Jobs",
                newName: "CreatedByUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs",
                newName: "IX_Jobs_CreatedByUserId");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Jobs",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "JobCategory",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventTypeId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventTypeTypeId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.TypeId);
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

            migrationBuilder.CreateIndex(
                name: "IX_Events_CreatedByUserId",
                table: "Events",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeTypeId",
                table: "Events",
                column: "EventTypeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteEvents_EventID",
                table: "UserFavoriteEvents",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteEvents_UserInfoID",
                table: "UserFavoriteEvents",
                column: "UserInfoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventTypes",
                principalColumn: "TypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventTypes_EventTypeTypeId",
                table: "Events",
                column: "EventTypeTypeId",
                principalTable: "EventTypes",
                principalColumn: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_CreatedByUserId",
                table: "Events",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserInfoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_CreatedByUserId",
                table: "Jobs",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "UserInfoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventTypes_EventTypeTypeId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_CreatedByUserId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_CreatedByUserId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "UserFavoriteEvents");

            migrationBuilder.DropIndex(
                name: "IX_Events_CreatedByUserId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventTypeId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_EventTypeTypeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "JobCategory",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTypeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventTypeTypeId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                table: "Jobs",
                newName: "JobCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Jobs_CreatedByUserId",
                table: "Jobs",
                newName: "IX_Jobs_JobCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "JobTitle",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddColumn<string>(
                name: "EventType",
                table: "Events",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Categories_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
