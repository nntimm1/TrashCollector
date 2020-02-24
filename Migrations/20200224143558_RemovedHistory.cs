using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Migrations
{
    public partial class RemovedHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_History_HistoryID",
                table: "Account");

            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropIndex(
                name: "IX_Account_HistoryID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "HistoryID",
                table: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HistoryID",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    HistoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Pickup = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.HistoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_HistoryID",
                table: "Account",
                column: "HistoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_History_HistoryID",
                table: "Account",
                column: "HistoryID",
                principalTable: "History",
                principalColumn: "HistoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
