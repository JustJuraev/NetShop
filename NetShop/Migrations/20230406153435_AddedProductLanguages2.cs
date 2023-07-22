using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetShop.Migrations
{
    public partial class AddedProductLanguages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLanguages",
                table: "ProductLanguages");

            migrationBuilder.DropIndex(
                name: "IX_ProductLanguages_Id",
                table: "ProductLanguages");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "ProductLanguages",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductLanguages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLanguages",
                table: "ProductLanguages",
                columns: new[] { "Id", "Language" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductLanguages",
                table: "ProductLanguages");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "ProductLanguages",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ProductLanguages",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductLanguages",
                table: "ProductLanguages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLanguages_Id",
                table: "ProductLanguages",
                column: "Id");
        }
    }
}
