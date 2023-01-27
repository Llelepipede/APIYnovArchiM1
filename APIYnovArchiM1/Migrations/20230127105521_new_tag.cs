using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIYnovArchiM1.Migrations
{
    public partial class new_tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "QrCode",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Tags",
                newName: "IDRace");

            migrationBuilder.AddColumn<string>(
                name: "QrcodeName",
                table: "Tags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QuizzText",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QrcodeName",
                table: "Tags");

            migrationBuilder.RenameColumn(
                name: "IDRace",
                table: "Tags",
                newName: "Longitude");

            migrationBuilder.AddColumn<int>(
                name: "Latitude",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "QrCode",
                table: "Tags",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Answer",
                table: "QuizzText",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
