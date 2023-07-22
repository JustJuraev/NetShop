using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NetShop.Migrations
{
    public partial class AddedOrderBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Basket",
                table: "Orders");

            migrationBuilder.CreateTable(
                name: "OrderBaskets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(type: "text", nullable: false),
                    ProductCount = table.Column<int>(type: "integer", nullable: false),
                    OrderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderBaskets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderBaskets_Id",
                table: "OrderBaskets",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderBaskets");

            migrationBuilder.AddColumn<string[]>(
                name: "Basket",
                table: "Orders",
                type: "text[]",
                nullable: false,
                defaultValue: new string[0]);
        }
    }
}
