using System;
using data.rarecarat.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace data.rarecarat.Context
{
    public partial class RarecaratContext : DbContext
    {
        public RarecaratContext()
        {
        }

        public RarecaratContext(DbContextOptions<RarecaratContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diamond> Diamonds { get; set; }
        public DbSet<Retailer> Retailer { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("???");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
