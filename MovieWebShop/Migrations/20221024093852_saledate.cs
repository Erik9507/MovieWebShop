using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebShop.Migrations
{
    public partial class saledate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLogItem");

            migrationBuilder.DropTable(
                name: "OrderLogEntries");

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleEnd",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SaleStart",
                table: "Movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SaleEnd",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "SaleStart",
                table: "Movies");

            migrationBuilder.CreateTable(
                name: "OrderLogEntries",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
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
                    OrderLogEntryEntryId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
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
    }
}
