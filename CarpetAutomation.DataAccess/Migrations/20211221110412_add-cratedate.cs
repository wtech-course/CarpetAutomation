using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpetAutomation.DataAccess.Migrations
{
    public partial class addcratedate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7d1d76ec-6781-41ca-83d1-98a12acb0518");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a4f10863-9022-4b71-a1e2-b888e7913052", "56147283-7f0f-4bb1-a0e0-5cad81dbb7ae", "user", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "a4f10863-9022-4b71-a1e2-b888e7913052");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Companies");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d1d76ec-6781-41ca-83d1-98a12acb0518", "c90dcbb3-c2cf-4a7f-97aa-cc99fb1a1197", "user", null });
        }
    }
}
