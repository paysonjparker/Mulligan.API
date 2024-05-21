﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mulligan.API.Data;

#nullable disable

namespace Mulligan.API.Migrations
{
    [DbContext(typeof(MulliganDbContext))]
    [Migration("20240521195256_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mulligan.API.Models.Domain.GolfCourse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("CourseRating")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Par")
                        .HasColumnType("int");

                    b.Property<int>("SlopeRating")
                        .HasColumnType("int");

                    b.Property<string>("Subdivision")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Yardage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("GolfCourse");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Post");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.Score", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Differential")
                        .HasColumnType("real");

                    b.Property<int?>("GolfCourseId")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GolfCourseId");

                    b.HasIndex("UserId");

                    b.ToTable("Score");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GolfCourseId")
                        .HasColumnType("int");

                    b.Property<float>("HandicapIndex")
                        .HasColumnType("real");

                    b.Property<string>("HomeCourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GolfCourseId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.Post", b =>
                {
                    b.HasOne("Mulligan.API.Models.Domain.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.Score", b =>
                {
                    b.HasOne("Mulligan.API.Models.Domain.GolfCourse", "GolfCourse")
                        .WithMany("Scores")
                        .HasForeignKey("GolfCourseId");

                    b.HasOne("Mulligan.API.Models.Domain.User", "User")
                        .WithMany("Scores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GolfCourse");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.User", b =>
                {
                    b.HasOne("Mulligan.API.Models.Domain.GolfCourse", "GolfCourse")
                        .WithMany("Users")
                        .HasForeignKey("GolfCourseId");

                    b.Navigation("GolfCourse");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.GolfCourse", b =>
                {
                    b.Navigation("Scores");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Mulligan.API.Models.Domain.User", b =>
                {
                    b.Navigation("Posts");

                    b.Navigation("Scores");
                });
#pragma warning restore 612, 618
        }
    }
}