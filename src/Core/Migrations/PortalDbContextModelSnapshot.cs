﻿// <auto-generated />
using System;
using Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Migrations
{
    [DbContext(typeof(PortalDbContext))]
    partial class PortalDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Models.EventInfo", b =>
                {
                    b.Property<int>("EventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventID"), 1L, 1);

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<string>("EventAddress")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<DateTime>("EventCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("EventTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsInativo")
                        .HasColumnType("bit");

                    b.HasKey("EventID");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Core.Models.JobInfo", b =>
                {
                    b.Property<int>("JobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobID"), 1L, 1);

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<bool>("IsInativo")
                        .HasColumnType("bit");

                    b.Property<string>("JobAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobCategory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JobCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("JobID");

                    b.HasIndex("CreatedByUserId");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("Core.Models.UserFavoriteEvent", b =>
                {
                    b.Property<int>("UserFavoriteEventID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFavoriteEventID"), 1L, 1);

                    b.Property<int>("EventID")
                        .HasColumnType("int");

                    b.Property<int>("UserInfoID")
                        .HasColumnType("int");

                    b.HasKey("UserFavoriteEventID");

                    b.HasIndex("EventID");

                    b.HasIndex("UserInfoID");

                    b.ToTable("UserFavoriteEvents");
                });

            modelBuilder.Entity("Core.Models.UserFavoriteJob", b =>
                {
                    b.Property<int>("UserFavoriteJobID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserFavoriteJobID"), 1L, 1);

                    b.Property<int>("JobID")
                        .HasColumnType("int");

                    b.Property<int>("UserInfoID")
                        .HasColumnType("int");

                    b.HasKey("UserFavoriteJobID");

                    b.HasIndex("JobID");

                    b.HasIndex("UserInfoID");

                    b.ToTable("UserFavoriteJobs");
                });

            modelBuilder.Entity("Core.Models.UserInfo", b =>
                {
                    b.Property<int>("UserInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserInfoId"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("UserPhone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserInfoId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Models.EventInfo", b =>
                {
                    b.HasOne("Core.Models.UserInfo", "EventCreatedByUser")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EventCreatedByUser");
                });

            modelBuilder.Entity("Core.Models.JobInfo", b =>
                {
                    b.HasOne("Core.Models.UserInfo", "CreatedByUser")
                        .WithMany("CreatedJobs")
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedByUser");
                });

            modelBuilder.Entity("Core.Models.UserFavoriteEvent", b =>
                {
                    b.HasOne("Core.Models.EventInfo", "EventInfo")
                        .WithMany("UsersWhoFavorited")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.UserInfo", "UserInfo")
                        .WithMany("FavoriteEvents")
                        .HasForeignKey("UserInfoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventInfo");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Core.Models.UserFavoriteJob", b =>
                {
                    b.HasOne("Core.Models.JobInfo", "JobInfo")
                        .WithMany("UsersWhoFavorited")
                        .HasForeignKey("JobID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Models.UserInfo", "UserInfo")
                        .WithMany("FavoriteJobs")
                        .HasForeignKey("UserInfoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JobInfo");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("Core.Models.EventInfo", b =>
                {
                    b.Navigation("UsersWhoFavorited");
                });

            modelBuilder.Entity("Core.Models.JobInfo", b =>
                {
                    b.Navigation("UsersWhoFavorited");
                });

            modelBuilder.Entity("Core.Models.UserInfo", b =>
                {
                    b.Navigation("CreatedEvents");

                    b.Navigation("CreatedJobs");

                    b.Navigation("FavoriteEvents");

                    b.Navigation("FavoriteJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
