﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.CreateTable(
                 name: "AccessProfiles",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     ProfileID = table.Column<string>(type: "text", nullable: true),
                     ProfileName = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_AccessProfiles", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "AccessSettings",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     ProfileID = table.Column<string>(type: "text", nullable: true),
                     AccessObject = table.Column<string>(type: "text", nullable: true),
                     Grant = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_AccessSettings", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "Accounts",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     LegalCode = table.Column<string>(type: "text", nullable: true),
                     Name = table.Column<string>(type: "text", nullable: true),
                     Description = table.Column<string>(type: "text", nullable: true),
                     Address = table.Column<string>(type: "text", nullable: true),
                     Phone = table.Column<string>(type: "text", nullable: true),
                     Email = table.Column<string>(type: "text", nullable: true),
                     Supplier = table.Column<bool>(type: "boolean", nullable: false),
                     Buyer = table.Column<bool>(type: "boolean", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Accounts", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "AccountSettings",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     BuyerWS = table.Column<string>(type: "text", nullable: true),
                     SupplierWS = table.Column<string>(type: "text", nullable: true),
                     BillingSettings = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_AccountSettings", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "Barcodes",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountId = table.Column<string>(type: "text", nullable: true),
                     ProductID = table.Column<string>(type: "text", nullable: true),
                     Barcode = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Barcodes", x => x.Id);
                 });

             migrationBuilder.CreateTable(
                 name: "Catalogues",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     ProductID = table.Column<string>(type: "text", nullable: false),
                     SourceCode = table.Column<string>(type: "text", nullable: true),
                     Name = table.Column<string>(type: "text", nullable: true),
                     Description = table.Column<string>(type: "text", nullable: true),
                     Unit = table.Column<string>(type: "text", nullable: true),
                     Status = table.Column<string>(type: "text", nullable: true),
                     LastChangeDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Catalogues", x => x.Id);
                 });

             migrationBuilder.CreateTable(
                 name: "ConnectionSettings",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     ConnectedAccountID = table.Column<string>(type: "text", nullable: true),
                     AsBuyer = table.Column<bool>(type: "boolean", nullable: false),
                     AsSupplier = table.Column<bool>(type: "boolean", nullable: false),
                     PriceTypes = table.Column<string>(type: "text", nullable: true),
                     ConnectionStatus = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ConnectionSettings", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "ErrorCodes",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     Code = table.Column<string>(type: "text", nullable: true),
                     Description = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ErrorCodes", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "ExchangeLog",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     TransactionID = table.Column<string>(type: "text", nullable: true),
                     Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                     MessageID = table.Column<string>(type: "text", nullable: true),
                     Status = table.Column<string>(type: "text", nullable: true),
                     ErrorCode = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ExchangeLog", x => x.id);
                 });


             migrationBuilder.CreateTable(
                 name: "InvoiceDetails",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     InvoiceID = table.Column<string>(type: "text", nullable: true),
                     ProductID = table.Column<string>(type: "text", nullable: true),
                     Unit = table.Column<string>(type: "text", nullable: true),
                     Quantity = table.Column<decimal>(type: "numeric", nullable: true),
                     Price = table.Column<decimal>(type: "numeric", nullable: true),
                     Amount = table.Column<decimal>(type: "numeric", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_InvoiceDetails", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "InvoiceHeaders",
                 columns: table => new
                 {
                     ID = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     OrderID = table.Column<string>(type: "text", nullable: true),
                     InvoiceID = table.Column<string>(type: "text", nullable: true),
                     Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                     Number = table.Column<decimal>(type: "numeric", nullable: true),
                     Amount = table.Column<decimal>(type: "numeric", nullable: true),
                     StatusID = table.Column<string>(type: "text", nullable: true),
                     WaybillNumber = table.Column<string>(type: "text", nullable: true),
                     PaymentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_InvoiceHeaders", x => x.ID);
                 });

             migrationBuilder.CreateTable(
                 name: "Invoices",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     OrderID = table.Column<string>(type: "text", nullable: true),
                     Package = table.Column<string>(type: "text", nullable: true),
                     Period = table.Column<string>(type: "text", nullable: true),
                     Number = table.Column<string>(type: "text", nullable: true),
                     DueDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                     Amount = table.Column<decimal>(type: "numeric", nullable: false),
                     Status = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Invoices", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "Messages",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     MessageID = table.Column<string>(type: "text", nullable: true),
                     Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                     SenderID = table.Column<string>(type: "text", nullable: true),
                     ReceiverID = table.Column<string>(type: "text", nullable: true),
                     Type = table.Column<string>(type: "text", nullable: true),
                     JSONBody = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Messages", x => x.Id);
                 });

             migrationBuilder.CreateTable(
     name: "OrderHeaders",
     columns: table => new
     {
         Id = table.Column<int>(type: "integer", nullable: false)
             .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
         AccountID = table.Column<string>(type: "text", nullable: false),
         OrderID = table.Column<string>(type: "text", nullable: false),
         Date = table.Column<DateTime>(type: "timestamp", nullable: false),
         Number = table.Column<string>(type: "text", nullable: false),
         SenderID = table.Column<string>(type: "text", nullable: false),
         ReceiverID = table.Column<string>(type: "text", nullable: false),
         ShopID = table.Column<string>(type: "text", nullable: false),
         Amount = table.Column<decimal>(type: "numeric", nullable: true),
         StatusID = table.Column<decimal>(type: "numeric", nullable: false),
         SendStatus = table.Column<int>(type: "integer", nullable: false)
     },
     constraints: table =>
     {
         table.PrimaryKey("PK_OrderHeaders", x => x.Id);
     });


             migrationBuilder.CreateTable(
                 name: "OrderStatus",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     StatusID = table.Column<string>(type: "text", nullable: true),
                     StatusName = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_OrderStatus", x => x.Id);
                 });

             migrationBuilder.CreateTable(
                 name: "OrderStatusHistory",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     OrderID = table.Column<string>(type: "text", nullable: true),
                     Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                     StatusID = table.Column<int>(type: "integer", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_OrderStatusHistory", x => x.Id);
                 });

             migrationBuilder.CreateTable(
                 name: "PositionName",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     PriceTypeID = table.Column<string>(type: "text", nullable: true),
                     Name = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_PositionName", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "PriceList",
                 columns: table => new
                 {
                     ID = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                     ProductID = table.Column<string>(type: "text", nullable: true),
                     PriceType = table.Column<string>(type: "text", nullable: true),
                     Unit = table.Column<string>(type: "text", nullable: true),
                     Price = table.Column<decimal>(type: "numeric", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_PriceList", x => x.ID);
                 });

             migrationBuilder.CreateTable(
                 name: "ProductCategories",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     CategoryID = table.Column<string>(type: "text", nullable: true),
                     ParentFolder = table.Column<string>(type: "text", nullable: true),
                     Code = table.Column<string>(type: "text", nullable: true),
                     Name = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ProductCategories", x => x.Id);
                 });

             migrationBuilder.CreateTable(
                 name: "ProductsByCategories",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     ProductID = table.Column<string>(type: "text", nullable: true),
                     CategoryID = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ProductsByCategories", x => x.Id);
                 });

             migrationBuilder.CreateTable(
                 name: "ProductsStocks",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     ProductID = table.Column<string>(type: "text", nullable: true),
                     ShopID = table.Column<string>(type: "text", nullable: true),
                     Quantity = table.Column<decimal>(type: "numeric", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ProductsStocks", x => x.Id);
                 });

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
                     InTimeOrders = table.Column<int>(type: "integer", nullable: false)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_ServiceLevels", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "Shops",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     ShopID = table.Column<string>(type: "text", nullable: true),
                     SourceCode = table.Column<string>(type: "text", nullable: true),
                     Name = table.Column<string>(type: "text", nullable: true),
                     Description = table.Column<string>(type: "text", nullable: true),
                     Address = table.Column<string>(type: "text", nullable: true),
                     ContactPerson = table.Column<string>(type: "text", nullable: true),
                     ContactNumber = table.Column<string>(type: "text", nullable: true),
                     Email = table.Column<string>(type: "text", nullable: true),
                     Region = table.Column<string>(type: "text", nullable: true),
                     Format = table.Column<string>(type: "text", nullable: true),
                     GPS = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Shops", x => x.Id);
                 });



             migrationBuilder.CreateTable(
                 name: "UserPositions",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     PositionID = table.Column<string>(type: "text", nullable: true),
                     PositionName = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_UserPositions", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "Users",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     AccountID = table.Column<string>(type: "text", nullable: true),
                     UserID = table.Column<string>(type: "text", nullable: true),
                     FirstName = table.Column<string>(type: "text", nullable: true),
                     LastName = table.Column<string>(type: "text", nullable: true),
                     ContactNumber = table.Column<string>(type: "text", nullable: true),
                     Email = table.Column<string>(type: "text", nullable: true),
                     Description = table.Column<string>(type: "text", nullable: true),
                     PositionInCompany = table.Column<string>(type: "text", nullable: true),
                     Password = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_Users", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "UserSettings",
                 columns: table => new
                 {
                     id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     UserID = table.Column<string>(type: "text", nullable: true),
                     ProfileID = table.Column<string>(type: "text", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_UserSettings", x => x.id);
                 });

             migrationBuilder.CreateTable(
                 name: "OrderDetails",
                 columns: table => new
                 {
                     Id = table.Column<int>(type: "integer", nullable: false)
                         .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                     OrderHeaderID = table.Column<string>(type: "text", nullable: true),
                     ProductID = table.Column<string>(type: "text", nullable: true),
                     Unit = table.Column<string>(type: "text", nullable: true),
                     Quantity = table.Column<decimal>(type: "numeric", nullable: true),
                     Price = table.Column<decimal>(type: "numeric", nullable: true),
                     Amount = table.Column<decimal>(type: "numeric", nullable: true),
                     ReservedQuantity = table.Column<decimal>(type: "numeric", nullable: true),
                     OrderHeadersId = table.Column<int>(type: "integer", nullable: true)
                 },
                 constraints: table =>
                 {
                     table.PrimaryKey("PK_OrderDetails", x => x.Id);
                     table.ForeignKey(
                         name: "FK_OrderDetails_OrderHeaders_OrderHeadersId",
                         column: x => x.OrderHeadersId,
                         principalTable: "OrderHeaders",
                         principalColumn: "Id");
                 });

             migrationBuilder.CreateIndex(
                 name: "IX_OrderDetails_OrderHeadersId",
                 table: "OrderDetails",
                 column: "OrderHeadersId");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /* migrationBuilder.DropTable(
                 name: "AccessProfiles");

             migrationBuilder.DropTable(
                 name: "AccessSettings");

             migrationBuilder.DropTable(
                 name: "Accounts");

             migrationBuilder.DropTable(
                 name: "AccountSettings");

             migrationBuilder.DropTable(
                 name: "Barcodes");

             migrationBuilder.DropTable(
                 name: "Catalogues");

             migrationBuilder.DropTable(
                 name: "ConnectionSettings");

             migrationBuilder.DropTable(
                 name: "ErrorCodes");

             migrationBuilder.DropTable(
                 name: "ExchangeLog");



             migrationBuilder.DropTable(
                 name: "InvoiceDetails");

             migrationBuilder.DropTable(
                 name: "InvoiceHeaders");

             migrationBuilder.DropTable(
                 name: "Invoices");

             migrationBuilder.DropTable(
                 name: "Messages");

             migrationBuilder.DropTable(
                 name: "OrderDetails");

             migrationBuilder.DropTable(
                 name: "OrderStatus");

             migrationBuilder.DropTable(
                 name: "OrderStatusHistory");

             migrationBuilder.DropTable(
                 name: "PositionName");

             migrationBuilder.DropTable(
                 name: "PriceList");

             migrationBuilder.DropTable(
                 name: "ProductCategories");

             migrationBuilder.DropTable(
                 name: "ProductsByCategories");

             migrationBuilder.DropTable(
                 name: "ProductsStocks");

             migrationBuilder.DropTable(
                 name: "ServiceLevels");

             migrationBuilder.DropTable(
                 name: "Shops");



             migrationBuilder.DropTable(
                 name: "UserPositions");

             migrationBuilder.DropTable(
                 name: "Users");

             migrationBuilder.DropTable(
                 name: "UserSettings");

             migrationBuilder.DropTable(
                 name: "OrderHeaders");*/
        }
    }
        }
