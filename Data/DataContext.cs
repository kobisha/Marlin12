﻿using Marlin.sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace Marlin.sqlite.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        // Define your DbSet properties here

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<OrderHeaders> OrderHeaders { get; set; }
        public DbSet<Catalogues> Catalogues { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistory { get; set; }
        public DbSet<PriceList> PriceList { get; set; }
        public DbSet<AccessProfiles> AccessProfiles { get; set; }
        public DbSet<AccessSettings> AccessSettings { get; set; }
        public DbSet<AccountSettings> AccountSettings { get; set; }
        public DbSet<ConnectionSettings> ConnectionSettings { get; set; }
        public DbSet<ErrorCodes> ErrorCodes { get; set; }
        public DbSet<ExchangeLog> ExchangeLog { get; set; }
        public DbSet<Invoices> Invoices { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<PositionName> PositionName { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<UserPositions> UserPositions { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<ProductsByCategories> ProductsByCategories { get; set; }
        public DbSet<Barcodes> Barcodes { get; set; }
        public DbSet<ProductCategories> ProductCategories { get; set; }
        public DbSet<OrderHeaders> HeadersData { get; set; }
        public DbSet<OrderDetails> DetailsData { get; set; }
        public DbSet<StocksOfProducts> ProductsStocks { get; set; }

        public DbSet<ServiceLevels> ServiceLevels { get; set; }

        public DbSet<temTable> Table { get; set; }
        public DbSet<OrderFront> frontOrders { get; set; }
        public DbSet<detailsFront> frontDetails { get; set; }

        public DbSet<SLAByCategory> sLAByCategories { get; set; }
        public DbSet<SLAByOrder> sLAByOrders { get; set; }
        public DbSet<SLAByProducts> SLAByProducts { get; set; }
        public DbSet<SLAByShops> SLAByShops { get; set; }
        public DbSet<SLAByVendors> SLAByVendors { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<temTable>();
            //modelBuilder.Ignore<OrderFront>();
            //modelBuilder.Ignore<detailsFront>();

            // Add other model configurations here
            

            base.OnModelCreating(modelBuilder);
        }





    }

}

