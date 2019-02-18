﻿// <auto-generated />
using System;
using AquaLearn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AquaLearn.Data.Migrations
{
    [DbContext(typeof(AquaLearnDbContext))]
    partial class AquaLearnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AquaLearn.Domain.Models.Classroom", b =>
                {
                    b.Property<int>("ClassroomId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("ClassroomId");

                    b.ToTable("Classroom");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Exhibit", b =>
                {
                    b.Property<int>("ExhibitId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("WaterTypeId");

                    b.HasKey("ExhibitId");

                    b.HasIndex("WaterTypeId");

                    b.ToTable("Exhibit");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Fish", b =>
                {
                    b.Property<int>("FishId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("ExhibitId");

                    b.Property<string>("Name");

                    b.Property<bool>("Schooling");

                    b.Property<int?>("WaterTypeId");

                    b.HasKey("FishId");

                    b.HasIndex("ExhibitId");

                    b.HasIndex("WaterTypeId");

                    b.ToTable("Fish");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Hazard", b =>
                {
                    b.Property<int>("HazardId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("ExhibitId");

                    b.Property<string>("Name");

                    b.Property<int?>("WaterTypeId");

                    b.HasKey("HazardId");

                    b.HasIndex("ExhibitId");

                    b.HasIndex("WaterTypeId");

                    b.ToTable("Hazard");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Plant", b =>
                {
                    b.Property<int>("PlantId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("ExhibitId");

                    b.Property<string>("Name");

                    b.Property<int?>("WaterTypeId");

                    b.HasKey("PlantId");

                    b.HasIndex("ExhibitId");

                    b.HasIndex("WaterTypeId");

                    b.ToTable("Plant");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Trash", b =>
                {
                    b.Property<int>("TrashId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int?>("ExhibitId");

                    b.Property<string>("Name");

                    b.Property<bool>("Schooling");

                    b.Property<int?>("WaterTypeId");

                    b.HasKey("TrashId");

                    b.HasIndex("ExhibitId");

                    b.HasIndex("WaterTypeId");

                    b.ToTable("Trash");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassroomId");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("Username");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.WaterType", b =>
                {
                    b.Property<int>("WaterTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("WaterTypeId");

                    b.ToTable("WaterType");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Exhibit", b =>
                {
                    b.HasOne("AquaLearn.Domain.Models.WaterType", "WaterType")
                        .WithMany()
                        .HasForeignKey("WaterTypeId");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Fish", b =>
                {
                    b.HasOne("AquaLearn.Domain.Models.Exhibit")
                        .WithMany("Fishes")
                        .HasForeignKey("ExhibitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AquaLearn.Domain.Models.WaterType", "WaterType")
                        .WithMany()
                        .HasForeignKey("WaterTypeId");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Hazard", b =>
                {
                    b.HasOne("AquaLearn.Domain.Models.Exhibit")
                        .WithMany("Hazard")
                        .HasForeignKey("ExhibitId");

                    b.HasOne("AquaLearn.Domain.Models.WaterType", "WaterType")
                        .WithMany()
                        .HasForeignKey("WaterTypeId");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Plant", b =>
                {
                    b.HasOne("AquaLearn.Domain.Models.Exhibit")
                        .WithMany("Plants")
                        .HasForeignKey("ExhibitId");

                    b.HasOne("AquaLearn.Domain.Models.WaterType", "WaterType")
                        .WithMany()
                        .HasForeignKey("WaterTypeId");
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Quiz", b =>
                {
                    b.HasOne("AquaLearn.Domain.Models.User")
                        .WithMany("Quizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AquaLearn.Domain.Models.Trash", b =>
                {
                    b.HasOne("AquaLearn.Domain.Models.Exhibit")
                        .WithMany("Trash")
                        .HasForeignKey("ExhibitId");

                    b.HasOne("AquaLearn.Domain.Models.WaterType", "WaterType")
                        .WithMany()
                        .HasForeignKey("WaterTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
