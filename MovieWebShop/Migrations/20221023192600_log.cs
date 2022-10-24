using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebShop.Migrations
{
    public partial class log : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.CreateTable(
                name: "OrderLogEntries",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLogEntries", x => x.EntryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderLogItem",
                columns: table => new
                {
                    LogItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderLogEntryEntryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLogItem", x => x.LogItemId);
                    table.ForeignKey(
                        name: "FK_OrderLogItem_OrderLogEntries_OrderLogEntryEntryId",
                        column: x => x.OrderLogEntryEntryId,
                        principalTable: "OrderLogEntries",
                        principalColumn: "EntryId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLogItem_OrderLogEntryEntryId",
                table: "OrderLogItem",
                column: "OrderLogEntryEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLogItem");

            migrationBuilder.DropTable(
                name: "OrderLogEntries");

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "Description", "Director", "GenreId", "IsOnSale", "Price", "ReleaseYear", "SaleMessage", "SalePrice", "Stock", "Title" },
                values: new object[] { 1, "A story about momma and how she do be kinda big, brazy", "Momma Bigsson", 1, false, 150m, new DateTime(2022, 10, 20, 11, 8, 28, 474, DateTimeKind.Local).AddTicks(7645), "On sale!", 0m, 20, "Big Mommas House" });
        }
    }
}
