using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIYnovArchiM1.Migrations
{
    public partial class fixed_tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "QrCode",
                table: "Tags",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrCode",
                table: "Tags");
        }
    }
}
