using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoardApp.Data.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoardId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "37dc2b5d-3e2e-4429-8bb9-7c18d6ea1355", 0, "fa52c197-ca43-4d8b-b8f3-4a58a79c6ff3", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEBi3xBt/Hfdab7nCSJqDKzdTNDu+fHgv5WmKpvadGxjYLakYWdsbN3tC5AR5IbSeJA==", null, false, "207757b5-68e8-4fc7-8088-4ab46ac1b2a0", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Proggress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 28, 12, 19, 4, 824, DateTimeKind.Local).AddTicks(8708), "Implement better styling for all public pages", "37dc2b5d-3e2e-4429-8bb9-7c18d6ea1355", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 9, 13, 12, 19, 4, 824, DateTimeKind.Local).AddTicks(8735), "Create Android client app for the TaskBoard RestFul API", "37dc2b5d-3e2e-4429-8bb9-7c18d6ea1355", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 13, 12, 19, 4, 824, DateTimeKind.Local).AddTicks(8738), "Create Windows Forms desktop app client for the TaskBoard RestFul API", "37dc2b5d-3e2e-4429-8bb9-7c18d6ea1355", "Desktop Client App" },
                    { 4, 3, new DateTime(2023, 2, 13, 12, 19, 4, 824, DateTimeKind.Local).AddTicks(8740), "Implement [Create Task] page for adding new tasks", "37dc2b5d-3e2e-4429-8bb9-7c18d6ea1355", "Create Task" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "37dc2b5d-3e2e-4429-8bb9-7c18d6ea1355");
        }
    }
}
