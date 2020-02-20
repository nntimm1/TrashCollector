using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class NewControllerforCustomers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aa71487-b109-4927-9244-6bd4bd574016");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "122031fa-9d97-41dc-a3de-ecb4bf6bdd26", "6929522d-0a80-4cef-97c7-670c56c9a5e0", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "122031fa-9d97-41dc-a3de-ecb4bf6bdd26");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3aa71487-b109-4927-9244-6bd4bd574016", "11e297a3-d959-4f52-bf09-70d53233cd9b", "Customer", "CUSTOMER" });
        }
    }
}
