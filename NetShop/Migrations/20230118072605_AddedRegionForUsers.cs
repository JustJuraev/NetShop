using Microsoft.EntityFrameworkCore.Migrations;

namespace NetShop.Migrations
{
    public partial class AddedRegionForUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "ProductProductAddress");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "text",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ProductAddresses_ProductId",
            //    table: "ProductAddresses",
            //    column: "ProductId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ProductAddresses_Products_ProductId",
            //    table: "ProductAddresses",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_ProductAddresses_Products_ProductId",
        //        table: "ProductAddresses");

        //    migrationBuilder.DropIndex(
        //        name: "IX_ProductAddresses_ProductId",
        //        table: "ProductAddresses");

        //    migrationBuilder.DropColumn(
        //        name: "City",
        //        table: "Users");

        //    migrationBuilder.CreateTable(
        //        name: "ProductProductAddress",
        //        columns: table => new
        //        {
        //            ProductAddressesId = table.Column<int>(type: "integer", nullable: false),
        //            ProductsId = table.Column<int>(type: "integer", nullable: false)
        //        },
        //        constraints: table =>
        //        {
        //            table.PrimaryKey("PK_ProductProductAddress", x => new { x.ProductAddressesId, x.ProductsId });
        //            table.ForeignKey(
        //                name: "FK_ProductProductAddress_ProductAddresses_ProductAddressesId",
        //                column: x => x.ProductAddressesId,
        //                principalTable: "ProductAddresses",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //            table.ForeignKey(
        //                name: "FK_ProductProductAddress_Products_ProductsId",
        //                column: x => x.ProductsId,
        //                principalTable: "Products",
        //                principalColumn: "Id",
        //                onDelete: ReferentialAction.Cascade);
        //        });

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ProductProductAddress_ProductsId",
        //        table: "ProductProductAddress",
        //        column: "ProductsId");
        //}
    }
}
