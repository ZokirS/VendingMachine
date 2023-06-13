using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class beverageCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4fb58717-0175-4d87-bbe7-519684c11449", "AQAAAAEAACcQAAAAEGK1J+QabJ8xG7ffy3VmWu3R7nzafr0WKYVC+ggjkJm5ZS+pGRfcUcfAz0BK7PodsA==", "79f89e56-495a-4fe6-8905-574abbeb7a6c" });

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "ImageUrl" },
                values: new object[] { 10, "https://images.unsplash.com/photo-1561758033-48d52648ae8b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80.jpg" });

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "ImageUrl" },
                values: new object[] { 10, "https://images.unsplash.com/photo-1531384370597-8590413be50a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1974&q=80.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1cab35d3-7de2-4a77-9369-3108f8e0d3ca", "AQAAAAEAACcQAAAAEP3Zxxxj9RYHs0GxxrOS+DBeM3VPlJoSelGUVkmTIrUYszFVL9rl2HSLEi33vk2tjg==", "266aa303-6735-4042-80fa-e5257b865394" });

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Count", "ImageUrl" },
                values: new object[] { 0, null });

            migrationBuilder.UpdateData(
                table: "Beverages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Count", "ImageUrl" },
                values: new object[] { 0, null });
        }
    }
}
