using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class newAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "927db2a8-fb3d-4b8c-82b5-952967ee0073", "AQAAAAEAACcQAAAAELH87GPGJFN6jOzfnKX0KGi5yluC400wV7kDW8NYdYyJ26gdVj5KQhCS2my0Z8noqg==", "3b4fa0cb-394a-43e3-9148-d781a47c8b3d" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b421e928-0613-9ebd-a64c-f10b6a706e73", 0, "760bcd60-4912-4dff-81ab-bd829616e40e", "adam@gmail.com", true, null, null, false, null, "adam@gmail.com", "user", "AQAAAAEAACcQAAAAEArxdAA7VrYIKFSYoyTUedCObXL0WomyfKuCaW50WIg5e5thJTo2487h6mESW2TFQg==", "1234567890", false, "2f2d51ac-4565-425a-b958-41dc81576e68", false, "user" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b421e928-0613-9ebd-a64c-f10b6a706e73" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b421e928-0613-9ebd-a64c-f10b6a706e73" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b421e928-0613-9ebd-a64c-f10b6a706e73");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdad737c-3d1a-4876-8024-6c459e3f58a1", "AQAAAAEAACcQAAAAEH4zh7aJDBkK9cY/S3MUBkNdKEwa8B3t9WpNYL4Ji0fJQfCZyZ6Z6LD85qDHrnlfeQ==", "202a2eda-7cff-4446-b132-0d621fcbad8f" });
        }
    }
}
