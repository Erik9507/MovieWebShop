using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebShop.Migrations
{
    public partial class godhlpme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fa474d4-0246-47db-834e-5b44c2d3ae19",
                column: "ConcurrencyStamp",
                value: "a75801ef-752f-4cea-bd8f-69a21675aa48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d49bc437-f9e7-41c4-be19-c17ad1691612",
                column: "ConcurrencyStamp",
                value: "be65ea61-03ce-48d9-9cf6-c6790200fd37");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3af40ad-1031-4f69-ba90-c628cbcefcd8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22ebba23-2f51-4fe2-a713-2c4a56898489", "AQAAAAEAACcQAAAAEO8eQIR6X7fyS8OM/u/HY1bfNYQFS4wkVFmy71msa+yAlf1laoFbR+iGmE5ZpH++kg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9fa474d4-0246-47db-834e-5b44c2d3ae19",
                column: "ConcurrencyStamp",
                value: "c7528019-6528-4c61-8871-1466e07c69e1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d49bc437-f9e7-41c4-be19-c17ad1691612",
                column: "ConcurrencyStamp",
                value: "e1539a9a-f79c-448b-bbaf-cde1a5574474");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3af40ad-1031-4f69-ba90-c628cbcefcd8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "238abbd5-3a95-4a6b-a45a-b24a9bbf47aa", "AQAAAAEAACcQAAAAENKfDF6Je2t3Hs3pOM+4hJwSOEwhd4AYgFa349DG0+aUlkyUwBuBq1sB73CsF2nY/A==" });
        }
    }
}
