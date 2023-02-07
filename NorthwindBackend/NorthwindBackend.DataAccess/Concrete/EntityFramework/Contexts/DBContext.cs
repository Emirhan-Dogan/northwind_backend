using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using NorthwindBackend.Entities.Concrete;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.DataAccess.Concrete.EntityFramework.Contexts
{
    public class DBContext : DbContext
    {
        //ModelBuilder modelBuilder;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //modelBuilder.Entity<OrderDetail>(builder =>
            //{
            //    builder.HasNoKey();
            //    builder.ToTable("OrderDetails");
            //});

            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Directory.GetCurrentDirectory());
            configurationManager.AddJsonFile("appsettings.json");

            optionsBuilder.UseSqlServer(configurationManager.GetConnectionString("SQLServer"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
