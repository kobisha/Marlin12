using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class stoks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "ProductsStocks",
                columns: table => new
                {
                    AccountID = table.Column<string>(type: "text", nullable: true),
                    ProductID = table.Column<string>(type: "text", nullable: true),
                    ShopID = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductsStocks");

            
        }
    }
}
