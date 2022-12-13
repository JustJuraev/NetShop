using Microsoft.EntityFrameworkCore.Migrations;

namespace NetShop.Migrations
{
    public partial class AddedImageToCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Categories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProperties_PropertyId",
                table: "ProductProperties",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Products_ProductId",
                table: "ProductProperties",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProperties_Properties_PropertyId",
                table: "ProductProperties",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Products_ProductId",
                table: "ProductProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductProperties_Properties_PropertyId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_ProductId",
                table: "ProductProperties");

            migrationBuilder.DropIndex(
                name: "IX_ProductProperties_PropertyId",
                table: "ProductProperties");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Categories");
        }
    }
}
