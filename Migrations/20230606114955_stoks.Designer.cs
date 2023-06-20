﻿// <auto-generated />
using System;
using Marlin.sqlite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230606114955_stoks")]
    partial class stoks
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Marlin.sqlite.Models.AccessProfiles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("ProfileID")
                        .HasColumnType("text");

                    b.Property<string>("ProfileName")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("AccessProfiles");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.AccessSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccessObject")
                        .HasColumnType("text");

                    b.Property<string>("Grant")
                        .HasColumnType("text");

                    b.Property<string>("ProfileID")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("AccessSettings");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.AccountSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("BillingSettings")
                        .HasColumnType("text");

                    b.Property<string>("BuyerWS")
                        .HasColumnType("text");

                    b.Property<string>("SupplierWS")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("AccountSettings");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.Accounts", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<bool>("Buyer")
                        .HasColumnType("boolean");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("LegalCode")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<bool>("Supplier")
                        .HasColumnType("boolean");

                    b.HasKey("id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.Barcodes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountId")
                        .HasColumnType("text");

                    b.Property<string>("Barcode")
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Barcodes");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.Catalogues", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SourceCode")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("Unit")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.ConnectionSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<bool>("AsBuyer")
                        .HasColumnType("boolean");

                    b.Property<bool>("AsSupplier")
                        .HasColumnType("boolean");

                    b.Property<string>("ConnectedAccountID")
                        .HasColumnType("text");

                    b.Property<string>("ConnectionStatus")
                        .HasColumnType("text");

                    b.Property<string>("PriceTypes")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("ConnectionSettings");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.ErrorCodes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("ErrorCodes");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.ExchangeLog", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ErrorCode")
                        .HasColumnType("text");

                    b.Property<string>("MessageID")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<string>("TransactionID")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("ExchangeLog");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.InvoiceDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("InvoiceID")
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductID")
                        .HasColumnType("text");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<string>("Unit")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("InvoiceDetails");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.InvoiceHeader", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("InvoiceID")
                        .HasColumnType("text");

                    b.Property<decimal?>("Number")
                        .HasColumnType("numeric");

                    b.Property<string>("OrderID")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("PaymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StatusID")
                        .HasColumnType("text");

                    b.Property<string>("WaybillNumber")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("InvoiceHeaders");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.Invoices", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("DueDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Number")
                        .HasColumnType("text");

                    b.Property<string>("OrderID")
                        .HasColumnType("text");

                    b.Property<string>("Package")
                        .HasColumnType("text");

                    b.Property<string>("Period")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.Messages", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("JSONBody")
                        .HasColumnType("text");

                    b.Property<string>("MessageID")
                        .HasColumnType("text");

                    b.Property<string>("ReceiverID")
                        .HasColumnType("text");

                    b.Property<string>("SenderID")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.OrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<string>("OrderHeaderID")
                        .HasColumnType("text");

                    b.Property<int?>("OrderHeadersId")
                        .HasColumnType("integer");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("ProductID")
                        .HasColumnType("text");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<decimal?>("ReservedQuantity")
                        .HasColumnType("numeric");

                    b.Property<string>("Unit")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrderHeadersId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.OrderHeaders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrderID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReceiverID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShopID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("StatusID")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("OrderHeaders");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusID")
                        .HasColumnType("text");

                    b.Property<string>("StatusName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.OrderStatusHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderID")
                        .HasColumnType("text");

                    b.Property<string>("StatusID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderStatusHistory");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.PositionName", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PriceTypeID")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("PositionName");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.PriceList", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("PriceType")
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .HasColumnType("text");

                    b.Property<string>("Unit")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("PriceList");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.ProductCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("CategoryID")
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("ParentFolder")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.ProductsByCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("CategoryID")
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductsByCategories");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.ProductsStocks", b =>
                {
                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("ProductID")
                        .HasColumnType("text");

                    b.Property<decimal?>("Quantity")
                        .HasColumnType("numeric");

                    b.Property<string>("ShopID")
                        .HasColumnType("text");

                    b.ToTable("ProductsStocks");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.Shops", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<string>("ContactPerson")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Format")
                        .HasColumnType("text");

                    b.Property<string>("GPS")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Region")
                        .HasColumnType("text");

                    b.Property<string>("ShopID")
                        .HasColumnType("text");

                    b.Property<string>("SourceCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.UserPositions", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("PositionID")
                        .HasColumnType("text");

                    b.Property<string>("PositionName")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("UserPositions");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.UserSettings", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("ProfileID")
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("UserSettings");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.Users", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountID")
                        .HasColumnType("text");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PositionInCompany")
                        .HasColumnType("text");

                    b.Property<string>("UserID")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.OrderDetails", b =>
                {
                    b.HasOne("Marlin.sqlite.Models.OrderHeaders", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderHeadersId");
                });

            modelBuilder.Entity("Marlin.sqlite.Models.OrderHeaders", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}