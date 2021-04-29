using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using StockManagement.Models;

namespace StockManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<StockManagement.Models.CategoryModel> CategoryModel { get; set; }
        public DbSet<StockManagement.Models.CustomerModel> CustomerModel { get; set; }
        public DbSet<StockManagement.Models.ProductModel> ProductModel { get; set; }
        public DbSet<StockManagement.Models.PurchaseModel> PurchaseModel { get; set; }
        public DbSet<StockManagement.Models.PurchaseDetailsModel> PurchaseDetailsModel { get; set; }
        public DbSet<StockManagement.Models.SalesModel> SalesModel { get; set; }
        public DbSet<StockManagement.Models.SalesDetailsModel> SalesDetailsModel { get; set; }
        public DbSet<StockManagement.Models.StockModel> StockModel { get; set; }
        public object ProductStockViewModel { get; internal set; }
    }
}
