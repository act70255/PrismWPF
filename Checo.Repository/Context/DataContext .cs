using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Checo.Repository.Entity;

#nullable disable

namespace Checo.Repository.Context
{
    public partial class DataContext : DbContext
    { 
        public string connectString = "Data Source=Storage.db";

        //protected readonly IConfiguration Configuration;
        public DataContext()//(IConfiguration configuration)
        {
            //Configuration = configuration;
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer(connectString);
                optionsBuilder.UseSqlite(connectString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).HasColumnType("VARCHAR");
                entity.Property(e => e.Company).HasColumnType("VARCHAR");
                entity.Property(e => e.CreateTime).HasColumnType("DATETIME");
                entity.Property(e => e.UpdateTime).HasColumnType("DATETIME");
            });
            modelBuilder.Entity<Trade>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.TradeNO).HasColumnType("VARCHAR");
                entity.Property(e => e.UserID).HasColumnType("VARCHAR");
                entity.Property(e => e.Amount).HasColumnType("NUMERIC");
                entity.Property(e => e.Subtotal).HasColumnType("NUMERIC");
                entity.Property(e => e.Unit).HasColumnType("NUMERIC");
                entity.Property(e => e.CreateTime).HasColumnType("DATETIME");
                entity.Property(e => e.UpdateTime).HasColumnType("DATETIME");
            });
            modelBuilder.Entity<TradeDetail>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.TradeID).HasColumnType("VARCHAR");
                entity.Property(e => e.Price).HasColumnType("NUMERIC");
                entity.Property(e => e.Amount).HasColumnType("NUMERIC");
                entity.Property(e => e.Unit).HasColumnType("NUMERIC");
                entity.Property(e => e.Subtotal).HasColumnType("NUMERIC");
                entity.Property(e => e.ItemID).HasColumnType("VARCHAR");
                entity.Property(e => e.CreateTime).HasColumnType("DATETIME");
                entity.Property(e => e.UpdateTime).HasColumnType("DATETIME");
            });
            modelBuilder.Entity<Item>(entity => {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Name).HasColumnType("VARCHAR");
                entity.Property(e => e.SerialNo).HasColumnType("VARCHAR");
                entity.Property(e => e.BatchNo).HasColumnType("VARCHAR");
                entity.Property(e => e.Price).HasColumnType("NUMERIC");
                entity.Property(e => e.StoredAmount).HasColumnType("NUMERIC");
                entity.Property(e => e.Unit).HasColumnType("NUMERIC");
                entity.Property(e => e.CreateTime).HasColumnType("DATETIME");
                entity.Property(e => e.UpdateTime).HasColumnType("DATETIME");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Trade> Trade { get; set; }
        public virtual DbSet<TradeDetail> TradeDetail { get; set; }
        public virtual DbSet<Item> Item { get; set; }
    }
}
