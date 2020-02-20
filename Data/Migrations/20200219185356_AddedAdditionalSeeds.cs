using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedAdditionalSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_ApplicationIdentityId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_ApplicationIdentityId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ApplicationIdentityId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Customer_ApplicationIdentityId",
                table: "Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "56f5b073-978c-427d-be7a-0bb22c913947");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ApplicationIdentityId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "ApplicationIdentityId",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "Customer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5d4bfdfd-f899-4c25-ab70-20971a7916a6", "4c514858-f00b-4ddd-89b7-3808ddddf6c3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1b702418-d3a6-4c40-93c4-b8457409f774", "1fd9018f-d806-4cce-b4be-9a44a1d62d1f", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "987ecc68-7934-487d-82a5-b053bf334b8f", "fd9fcd89-5ba8-4ac6-b8e3-31e7edb2a5ae", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_IdentityUserId",
                table: "Customer",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_IdentityUserId",
                table: "Customer",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customer_AspNetUsers_IdentityUserId",
                table: "Customer");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_IdentityUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_IdentityUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Customer_IdentityUserId",
                table: "Customer");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1b702418-d3a6-4c40-93c4-b8457409f774");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d4bfdfd-f899-4c25-ab70-20971a7916a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "987ecc68-7934-487d-82a5-b053bf334b8f");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "Customer");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationIdentityId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationIdentityId",
                table: "Customer",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "56f5b073-978c-427d-be7a-0bb22c913947", "6b528273-7522-46d5-a9e1-dd4893c17e01", "Admin", "ADMIN" });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ApplicationIdentityId",
                table: "Employee",
                column: "ApplicationIdentityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_ApplicationIdentityId",
                table: "Customer",
                column: "ApplicationIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customer_AspNetUsers_ApplicationIdentityId",
                table: "Customer",
                column: "ApplicationIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_ApplicationIdentityId",
                table: "Employee",
                column: "ApplicationIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
