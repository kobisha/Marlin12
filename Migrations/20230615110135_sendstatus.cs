using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class sendstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "SendStatus",
                table: "OrderHeaders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropColumn(
                name: "SendStatus",
                table: "OrderHeaders");

            
        }
    }
}
