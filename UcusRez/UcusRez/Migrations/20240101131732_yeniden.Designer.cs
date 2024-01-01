﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UcusRez.Models;

#nullable disable

namespace UcusRez.Migrations
{
    [DbContext(typeof(DbUcus))]
    [Migration("20240101131732_yeniden")]
    partial class yeniden
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UcusRez.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminID"));

                    b.Property<string>("AdminMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminID");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("UcusRez.Models.Bilet", b =>
                {
                    b.Property<int>("BiletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BiletId"));

                    b.Property<string>("KalkisSehri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KalkisTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KoltukNumarasi")
                        .HasColumnType("int");

                    b.Property<string>("VarisSehri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YolcuAd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YolcuCinsiyet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YolcuDogumTarihi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YolcuMail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YolcuPasaport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YolcuSoyad")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BiletId");

                    b.ToTable("Bilet");
                });

            modelBuilder.Entity("UcusRez.Models.Giris", b =>
                {
                    b.Property<int>("GirisID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GirisID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GirisID");

                    b.ToTable("Giris");
                });

            modelBuilder.Entity("UcusRez.Models.Guzergah", b =>
                {
                    b.Property<int>("GuzergahID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuzergahID"));

                    b.Property<string>("KalkisSehri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VarisSehri")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GuzergahID");

                    b.ToTable("Guzergah");
                });

            modelBuilder.Entity("UcusRez.Models.Kayit", b =>
                {
                    b.Property<int>("KayitID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KayitID"));

                    b.Property<string>("ConfKayitPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KayitMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KayitName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KayitPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KayitSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KayitID");

                    b.ToTable("Kayit");
                });

            modelBuilder.Entity("UcusRez.Models.Ucak", b =>
                {
                    b.Property<int>("UcakID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UcakID"));

                    b.Property<int?>("UcakCapacity")
                        .HasColumnType("int");

                    b.HasKey("UcakID");

                    b.ToTable("Ucak");
                });

            modelBuilder.Entity("UcusRez.Models.Ucus", b =>
                {
                    b.Property<int>("UcusID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UcusID"));

                    b.Property<int>("GuzergahID")
                        .HasColumnType("int");

                    b.Property<int>("UcakID")
                        .HasColumnType("int");

                    b.Property<DateTime>("UcusTime")
                        .HasColumnType("datetime2");

                    b.HasKey("UcusID");

                    b.HasIndex("GuzergahID");

                    b.HasIndex("UcakID");

                    b.ToTable("Ucus");
                });

            modelBuilder.Entity("UcusRez.Models.Ucus", b =>
                {
                    b.HasOne("UcusRez.Models.Guzergah", "Guzergah")
                        .WithMany()
                        .HasForeignKey("GuzergahID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UcusRez.Models.Ucak", "Ucak")
                        .WithMany()
                        .HasForeignKey("UcakID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guzergah");

                    b.Navigation("Ucak");
                });
#pragma warning restore 612, 618
        }
    }
}
