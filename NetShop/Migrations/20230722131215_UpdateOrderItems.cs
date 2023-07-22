using Microsoft.EntityFrameworkCore.Migrations;

namespace NetShop.Migrations
{
    public partial class UpdateOrderItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderBaskets",
                table: "OrderBaskets");

            migrationBuilder.RenameTable(
                name: "OrderBaskets",
                newName: "OrderItems");

            migrationBuilder.RenameIndex(
                name: "IX_OrderBaskets_Id",
                table: "OrderItems",
                newName: "IX_OrderItems_Id");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "OrderItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderBaskets");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_Id",
                table: "OrderBaskets",
                newName: "IX_OrderBaskets_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderBaskets",
                table: "OrderBaskets",
                column: "Id");
        }
    }
}
