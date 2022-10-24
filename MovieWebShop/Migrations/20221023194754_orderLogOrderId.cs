﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieWebShop.Migrations
{
    public partial class orderLogOrderId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderLogEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderLogEntries");
        }
    }
}
