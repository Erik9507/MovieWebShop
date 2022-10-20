using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebShop.Migrations
{
    public partial class sale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsOnSale",
                table: "Movies",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SaleMessage",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "ReleaseYear",
                value: new DateTime(2022, 10, 20, 10, 43, 22, 256, DateTimeKind.Local).AddTicks(8847));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOnSale",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SaleMessage",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "ReleaseYear",
                value: new DateTime(2022, 10, 20, 9, 48, 45, 721, DateTimeKind.Local).AddTicks(2385));
        }
    }
}
