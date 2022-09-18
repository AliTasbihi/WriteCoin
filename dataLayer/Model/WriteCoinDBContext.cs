using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dataLayer.Model
{
    public partial class WriteCoinDBContext : DbContext
    {
        public WriteCoinDBContext()
        {
        }

        public WriteCoinDBContext(DbContextOptions<WriteCoinDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EndPointCoin> EndPointCoins { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=WriteCoinDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EndPointCoin>(entity =>
            {
                entity.ToTable("EndPointCoin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.History)
                    .HasMaxLength(50)
                    .HasColumnName("history");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .HasColumnName("price");

                entity.Property(e => e.Time)
                    .HasMaxLength(50)
                    .HasColumnName("time");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
