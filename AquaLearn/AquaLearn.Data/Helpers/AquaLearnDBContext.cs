using AquaLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Data.Helpers
{
    public class AquaLearnDBContext
    {
        public AquaLearnDBContext()
        {
            
        }

        public AquaLearnDBContext(DbContextOptions<AquaLearnDBContext> options)
            : base(options)
        {
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=ajdotnet2019.database.windows.net;database=MovieNightDB;user id=sqladmin;password=Florida2019;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<WaterType>(entity =>
            {
                entity.ToTable("WaterType", "Environment");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

            });

            modelBuilder.Entity<Exhibit>(entity =>
          {
              entity.ToTable("Exhibit", "Environment");

              entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

              entity.HasOne(d => d.WaterType)
              .WithMany(WaterType => Exhibit)
              .HasForeignKey(d => d.WaterTypeId)
              .HasConstraintName("FK_Exhibit_WaterTypeId");
          });

            modelBuilder.Entity<Hazard>(entity =>
                    {
                        entity.ToTable("Hazards", "HumanEffects");

                        entity.Property(e => e.Name)
                            .IsRequired()
                            .HasMaxLength(100);

                        entity.Property(e => e.Description)
                            .IsRequired()
                            .HasMaxLength(500);
                    });

            modelBuilder.Entity<Trash>(entity =>
            {
                entity.Property(e => e.Name)
                         .IsRequired()
                         .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Fish>(entity =>
            {
                entity.ToTable("Fish", "MarineLife");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Schooling).HasMaxLength(2);

                entity.HasOne(d => d.WaterType)
                    .WithMany(p => p.Fish)
                    .HasForeignKey(d => d.WaterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fish_WaterTypeId");
            });

            modelBuilder.Entity<Plant>(entity =>
            {
                entity.ToTable("Fish", "MarineLife");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.HasOne(d => d.WaterType)
                    .WithMany(p => p.Fish)
                    .HasForeignKey(d => d.WaterTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Plant_WaterTypeId");
            });


        }
    }
}