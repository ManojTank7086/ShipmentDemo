using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ShipmentAPI.Models;

namespace ShipmentAPI.DBContext
{
    public partial class DemoContext : DbContext
    {
        public virtual DbSet<AppLogs> AppLogs { get; set; } = null!;
        public virtual DbSet<LoginInfo> LoginInfo { get; set; } = null!;
        public virtual DbSet<ShipmentInfo> ShipmentInfo { get; set; } = null!;
        public virtual DbSet<ShipmentPoint> ShipmentPoint { get; set; } = null!;
        public virtual DbSet<ShipmentStatus> ShipmentStatus { get; set; } = null!;
        public virtual DbSet<UpdateShipmentStatus> UpdateShipmentStatus { get; set; } = null!;
        public virtual DbSet<Vendor> Vendor { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppLogs>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<LoginInfo>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ShipmentInfo>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Consignee)
                    .WithMany(p => p.ShipmentInfoConsignee)
                    .HasForeignKey(d => d.ConsigneeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentInfo_Vendor1");

                entity.HasOne(d => d.Consignor)
                    .WithMany(p => p.ShipmentInfoConsignor)
                    .HasForeignKey(d => d.ConsignorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentInfo_Vendor");

                entity.HasOne(d => d.DestinationPoint)
                    .WithMany(p => p.ShipmentInfoDestinationPoint)
                    .HasForeignKey(d => d.DestinationPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentInfo_ShipmentPoint1");

                entity.HasOne(d => d.OriginPoint)
                    .WithMany(p => p.ShipmentInfoOriginPoint)
                    .HasForeignKey(d => d.OriginPointId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentInfo_ShipmentPoint");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.ShipmentInfo)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShipmentInfo_ShipmentStatus");
            });

            modelBuilder.Entity<ShipmentPoint>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ShipmentStatus>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<UpdateShipmentStatus>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.CreateDate).HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
