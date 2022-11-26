using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebShopDemo.Core.Migrations
{
    public partial class ProductAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, comment: "Primary Key"),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, comment: "Product Name"),
                    price = table.Column<decimal>(type: "numeric", nullable: false, comment: "Product Price"),
                    quantity = table.Column<int>(type: "integer", nullable: false, comment: "Product In Stock")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                },
                comment: "Product to sell");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
