using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarAPI.Models;

public partial class CarDbContext : DbContext
{
    public CarDbContext()
    {
    }

    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarCatalog> CarCatalogs { get; set; }
    public virtual DbSet<CarCatalogDealer1> CarCatalogs1 { get; set; }
    public virtual DbSet<CarCatalogDealer2> CarCatalogs2 { get; set; }
    public virtual DbSet<CarCatalogDealer3> CarCatalogs3 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        { }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarCatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Category");

            entity.ToTable("CarCatalog");

            entity.Property(e => e.Active)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Dealer)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
        modelBuilder.Entity<CarCatalog>()
           .ToTable("CarCatalog")
           .HasDiscriminator<string>("Dealer")
           .HasValue<CarCatalogDealer1>("GMC")
           .HasValue<CarCatalogDealer2>("Ford")
           .HasValue<CarCatalogDealer3>("Chrysler");
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
