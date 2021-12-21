using Microsoft.EntityFrameworkCore.Migrations;

namespace CarpetAutomation.DataAccess.Migrations
{
    public partial class twice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "9c83f7d4-e143-4a8d-aa0a-c267fc136d3c");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7d1d76ec-6781-41ca-83d1-98a12acb0518", "c90dcbb3-c2cf-4a7f-97aa-cc99fb1a1197", "user", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "7d1d76ec-6781-41ca-83d1-98a12acb0518");

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9c83f7d4-e143-4a8d-aa0a-c267fc136d3c", "3cd35cd2-600d-45b9-8e06-87d0e848f45a", "user", null });
        }
    }
}
