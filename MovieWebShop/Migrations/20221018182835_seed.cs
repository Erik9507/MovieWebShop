using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebShop.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[] { 1, "Comedy" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "Director", "GenreId", "Price", "ReleaseYear", "Stock", "Title" },
                values: new object[] { 1, "A story about momma and how she do be kinda big, brazy", "Momma Bigsson", 1, 150m, new DateTime(2022, 10, 18, 20, 28, 35, 780, DateTimeKind.Local).AddTicks(1892), 20, "Big Mommas House" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);
        }
    }
}
