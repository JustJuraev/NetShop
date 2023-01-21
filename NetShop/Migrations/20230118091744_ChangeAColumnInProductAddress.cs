using Microsoft.EntityFrameworkCore.Migrations;

namespace NetShop.Migrations
{
    public partial class ChangeAColumnInProductAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ProductAddresses");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "ProductAddresses",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "ProductAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ProductAddresses",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
