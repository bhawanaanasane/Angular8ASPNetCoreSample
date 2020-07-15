using Microsoft.EntityFrameworkCore.Migrations;

namespace FLA.Data.Migrations
{
    public partial class DriverNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DriverNotes",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoNumber",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DriverNotes",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PoNumber",
                table: "Orders");
        }
    }
}
