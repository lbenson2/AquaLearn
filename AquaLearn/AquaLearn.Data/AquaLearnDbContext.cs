﻿using AquaLearn.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AquaLearn.Data
{
    public class AquaLearnDbContext : DbContext
    {
        public DbSet<Role> Role { get; set; }
        public DbSet<Fish> Fish { get; set; }
        public DbSet<Plant> Plant { get; set; }
        public DbSet<Trash> Trash { get; set; }
        public DbSet<Hazard> Hazard { get; set; }
        public DbSet<Exhibit> Exhibit { get; set; }
        public DbSet<WaterType> WaterType { get; set; }
        public DbSet<User> User { get; set; }
        //public DbSet<Role> Role { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("data source=ajdotnet2019.database.windows.net;database=AquaLearnDB;user id=sqladmin;password=Florida2019;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Fish>().HasKey(e => e.FishId);
            builder.Entity<WaterType>().HasKey(e => e.WaterTypeId);
            builder.Entity<Plant>().HasKey(e => e.PlantId);
            builder.Entity<Trash>().HasKey(e => e.TrashId);
            builder.Entity<Exhibit>().HasKey(e => e.ExhibitId);
            builder.Entity<Hazard>().HasKey(e => e.HazardId);
            builder.Entity<User>().HasKey(e => e.UserId);
            builder.Entity<Role>().HasKey(e => e.RoleId);

        }

    }
}
