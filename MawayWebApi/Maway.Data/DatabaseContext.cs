using Maway.Data.Model;
using Maway.Data.Model.Supplements;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Maway.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
       : base(options)
        { }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<ItemAttribute> Attributes { get; set; }
        public DbSet<ItemAttributes> ItemAttributes { get; set; }
        public DbSet<ItemPrice> ItemTypePrices { get; set; }
        public DbSet<ItemExtras> ItemExtras { get; set; }
        public DbSet<Extras> Extras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasIndex(i => new { i.CompanyRegistryId })
                .HasName("Item_Registry_Id")
                .IsUnique();

            modelBuilder.Entity<ItemExtras>()
                .HasOne(bc => bc.ItemType)
                .WithMany(b => b.ItemExtras);
            
            modelBuilder.Entity<ItemAttributes>()
                .HasIndex(a => new { a.ItemTypeId, a.AttributeKey })
                .IsUnique()
                .HasName("Item_Attribute");

            modelBuilder.Entity<ItemAttributes>()
                .HasOne(i => i.ItemType)
                .WithMany(a => a.ItemAttributes);


            modelBuilder.Entity<ItemAttribute>().HasData(
                new { Key = "Gearbox", Icon = "cog" },
                new { Key = "AirCondition", Icon = "snowflage" },
                new { Key = "FuelType", Icon = "gaspump" },
                new { Key = "Doors", Icon = "dooropen" });

            modelBuilder.Entity<ItemType>().HasData(
                new ItemType { Id = 1, Title = "fiat 500", Image = "someimage.png" },
                new ItemType { Id = 2, Title = "fiat tipo", Image = "someimage.png" },
                new ItemType { Id = 3, Title = "leon", Image = "someimage.png" },
                new ItemType { Id = 4, Title = "vespa", Image = "someimage.png" });

            modelBuilder.Entity<ItemAttributes>().HasData(
                new { Id = 1, ItemTypeId = 1, AttributeKey = "Gearbox", Value = "Manual", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now },
                new { Id = 2, ItemTypeId = 1, AttributeKey = "AirCondition", Value = "Air condition", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now });

            modelBuilder.Entity<Item>().HasData(
                new { Id = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CompanyRegistryId = "KR123",  ItemTypeId=1 },
                new { Id = 2, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CompanyRegistryId = "KR124",  ItemTypeId=2 },
                new { Id = 3, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, CompanyRegistryId = "KR125",  ItemTypeId=3 });

        }
    }
}
