﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Models;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(СarsAppContext))]
    [Migration("20231108040109_addtime")]
    partial class addtime
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.23");

            modelBuilder.Entity("APICore.Models.Marks", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MarksCars");
                });

            modelBuilder.Entity("WebAPI.Models.ModelsCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("DVS")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<double>("engine_capacity")
                        .HasColumnType("REAL");

                    b.Property<string>("kuzov")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("ls")
                        .HasColumnType("REAL");

                    b.Property<int>("markID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("privod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("markID");

                    b.ToTable("ModelsCars");
                });

            modelBuilder.Entity("WebAPI.Models.ModelsCar", b =>
                {
                    b.HasOne("APICore.Models.Marks", "Mark")
                        .WithMany()
                        .HasForeignKey("markID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mark");
                });
#pragma warning restore 612, 618
        }
    }
}
