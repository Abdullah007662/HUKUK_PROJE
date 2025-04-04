﻿// <auto-generated />
using System;
using HUKUK_PROJE.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HUKUKPROJE.Migrations
{
    [DbContext(typeof(HukukContext))]
    [Migration("20250403224555_MiG11")]
    partial class MiG11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HUKUK_PROJE.Entities.About", b =>
                {
                    b.Property<int>("AboutID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AboutID"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("VarChar");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200)
                        .HasColumnType("VarChar");

                    b.Property<string>("SignatureUrl")
                        .HasMaxLength(200)
                        .HasColumnType("VarChar");

                    b.Property<string>("Title")
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("AboutID");

                    b.ToTable("Abouts");
                });

            modelBuilder.Entity("HUKUK_PROJE.Entities.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerID"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("VarChar");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("VarChar");

                    b.HasKey("BannerID");

                    b.ToTable("Banners");
                });

            modelBuilder.Entity("HUKUK_PROJE.Entities.Contact", b =>
                {
                    b.Property<int>("ContactID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContactID"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("AppointmentTime")
                        .HasColumnType("time");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("NameSurname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ContactID");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("HUKUK_PROJE.Entities.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeID"));

                    b.Property<string>("Department")
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.Property<string>("FacebookUrl")
                        .HasMaxLength(150)
                        .HasColumnType("VarChar");

                    b.Property<string>("InstagramUrl")
                        .HasMaxLength(200)
                        .HasColumnType("VarChar");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("VarChar");

                    b.Property<string>("TwitterUrl")
                        .HasMaxLength(150)
                        .HasColumnType("VarChar");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("HUKUK_PROJE.Entities.LawTypes", b =>
                {
                    b.Property<int>("LawTypesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LawTypesID"));

                    b.Property<string>("Type")
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("LawTypesID");

                    b.ToTable("LawTypes");
                });

            modelBuilder.Entity("HUKUK_PROJE.Entities.Service", b =>
                {
                    b.Property<int>("ServiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceID"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("VarChar");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(200)
                        .HasColumnType("VarChar");

                    b.Property<string>("Title")
                        .HasMaxLength(150)
                        .HasColumnType("VarChar");

                    b.HasKey("ServiceID");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("HUKUK_PROJE.Entities.Testimonial", b =>
                {
                    b.Property<int>("TestimonialID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestimonialID"));

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("VarChar");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(300)
                        .HasColumnType("VarChar");

                    b.Property<string>("NameSurname")
                        .HasMaxLength(30)
                        .HasColumnType("VarChar");

                    b.HasKey("TestimonialID");

                    b.ToTable("Testimonials");
                });
#pragma warning restore 612, 618
        }
    }
}
