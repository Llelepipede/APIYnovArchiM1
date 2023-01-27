using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIYnovArchiM1.Migrations
{
    public partial class order_in_tag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Tags");
        }
    }
}
