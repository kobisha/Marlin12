using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class bla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "ServiceLevels",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Vendor = table.Column<string>(type: "text", nullable: true),
                    Shop = table.Column<string>(type: "text", nullable: true),
                    ProductCategory = table.Column<string>(type: "text", nullable: true),
                    OrderNumber = table.Column<string>(type: "text", nullable: true),
                    OrderDate = table.Column<string>(type: "text", nullable: true),
                    Product = table.Column<string>(type: "text", nullable: true),
                    OrderedQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    OrderedAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    DeliveredQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    DeliveredAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    SLAByQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                    SLAByAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    InTimeOrders = table.Column<int>(type: "integer", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceLevels", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceLevels");


        }
    }
}
