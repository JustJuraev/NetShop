using Microsoft.EntityFrameworkCore.Migrations;

namespace NetShop.Migrations
{
    public partial class AddPropertyLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PropertyLanguages",
                columns: table => new
                {
                    PropertyId = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyLanguages", x => new { x.PropertyId, x.Language });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyLanguages");
        }
    }
}
