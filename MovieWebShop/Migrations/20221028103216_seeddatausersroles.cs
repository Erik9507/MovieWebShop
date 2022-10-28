using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebShop.Migrations
{
    public partial class seeddatausersroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fa474d4-0246-47db-834e-5b44c2d3ae19");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d49bc437-f9e7-41c4-be19-c17ad1691612", "f3af40ad-1031-4f69-ba90-c628cbcefcd8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d49bc437-f9e7-41c4-be19-c17ad1691612");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3af40ad-1031-4f69-ba90-c628cbcefcd8");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a17a5bbe-6f3f-44af-855c-28ec50eceb2d", "d4d7ccc5-3f91-4412-93e8-dc929dc82738", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "efd2b503-4910-48d4-903b-16ef0285418b", "a783a0c5-7a72-4c75-8535-f4e24d2b617a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ce02a491-dec2-4e08-936a-e64dd8ad72e1", 0, "205c4e1a-a3c7-47de-a815-736da7d3d8eb", "admin@test.se", true, false, null, "ADMIN@TEST.SE", "ADMIN@TEST.SE", "AQAAAAEAACcQAAAAEIC8n6RUlk5mBf0hfGdrbC96sjlDSdgCChyibgMa6OfLBQwTu0kMJyUaC6yzabKAgw==", null, true, "Admin", false, "admin@test.se" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "a17a5bbe-6f3f-44af-855c-28ec50eceb2d", "ce02a491-dec2-4e08-936a-e64dd8ad72e1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "efd2b503-4910-48d4-903b-16ef0285418b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "a17a5bbe-6f3f-44af-855c-28ec50eceb2d", "ce02a491-dec2-4e08-936a-e64dd8ad72e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a17a5bbe-6f3f-44af-855c-28ec50eceb2d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce02a491-dec2-4e08-936a-e64dd8ad72e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9fa474d4-0246-47db-834e-5b44c2d3ae19", "72088890-d1f6-472b-94aa-83b1071f1f3a", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d49bc437-f9e7-41c4-be19-c17ad1691612", "b680b605-fbc9-4da7-bcdd-807c555c25b9", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f3af40ad-1031-4f69-ba90-c628cbcefcd8", 0, "7af9eff7-8a79-4f30-a643-4e495644e12f", "admin@test.se", true, false, null, "ADMIN@TEST.SE", "ADMIN@TEST.SE", "AQAAAAEAACcQAAAAEGaGgefeKPAQOW9oAowqRgIVkhFwgbxtBFsJuzasaFQQZ5SDWnZiR4C44eGn/fG94w==", null, true, "Admin", false, "admin@test.se" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d49bc437-f9e7-41c4-be19-c17ad1691612", "f3af40ad-1031-4f69-ba90-c628cbcefcd8" });
        }
    }
}
