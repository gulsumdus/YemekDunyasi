﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YemekDünyasi.Models;

#nullable disable

namespace YemekDünyasi.Migrations
{
    [DbContext(typeof(YemekDünyasContext))]
    [Migration("20230710080409_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("YemekDünyasi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CategoryTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Döner"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Burger"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tavuk"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Pasta&Tatlı"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Tost&Sandviç"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Sokak Lezzetleri"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Kebap"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Pide"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Kahvaltı"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Lahmacun"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Ev yemekleri"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Kahve"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Vejetaryen"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Dünya Mutfağı"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Köfte"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Börek"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Çiğ Köfte"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Salata"
                        },
                        new
                        {
                            Id = 20,
                            Name = "İçecek"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Deniz Ürünleri"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Dondurma"
                        });
                });

            modelBuilder.Entity("YemekDünyasi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("UserId");

                    b.ToTable("OrderTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderDate = new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(742),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderDate = new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(743),
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            OrderDate = new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(744),
                            UserId = 3
                        },
                        new
                        {
                            Id = 4,
                            OrderDate = new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(745),
                            UserId = 4
                        },
                        new
                        {
                            Id = 5,
                            OrderDate = new DateTime(2023, 7, 10, 11, 4, 8, 992, DateTimeKind.Local).AddTicks(746),
                            UserId = 5
                        });
                });

            modelBuilder.Entity("YemekDünyasi.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItemTable");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("ProductTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "İskender",
                            Price = 120m,
                            RestaurantId = 111
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kuzu Şiş",
                            Price = 120m,
                            RestaurantId = 111
                        },
                        new
                        {
                            Id = 3,
                            Name = "Tavuk Şiş",
                            Price = 120m,
                            RestaurantId = 111
                        },
                        new
                        {
                            Id = 4,
                            Name = "Lokma",
                            Price = 120m,
                            RestaurantId = 111
                        },
                        new
                        {
                            Id = 5,
                            Name = "Alinazik",
                            Price = 120m,
                            RestaurantId = 111
                        });
                });

            modelBuilder.Entity("YemekDünyasi.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("RestaurantTable");

                    b.HasData(
                        new
                        {
                            Id = 111,
                            Address = "Batıkent",
                            CategoryId = 1,
                            Name = "Ala kebap",
                            TelNo = "08505678990"
                        },
                        new
                        {
                            Id = 112,
                            Address = "Kızılay",
                            CategoryId = 7,
                            Name = "Lezzet Sofrası",
                            TelNo = "03123456789"
                        },
                        new
                        {
                            Id = 113,
                            Address = "Çankaya",
                            CategoryId = 8,
                            Name = "Pizza Evi",
                            TelNo = "03127894561"
                        },
                        new
                        {
                            Id = 114,
                            Address = "Bahçelievler",
                            CategoryId = 2,
                            Name = "Burger Land",
                            TelNo = "03125678321"
                        },
                        new
                        {
                            Id = 115,
                            Address = "Gölbaşı",
                            CategoryId = 21,
                            Name = "Deniz Mahsülleri",
                            TelNo = "03123450987"
                        },
                        new
                        {
                            Id = 116,
                            Address = "Etimesgut",
                            CategoryId = 5,
                            Name = "Tost Köşesi",
                            TelNo = "03127895678"
                        },
                        new
                        {
                            Id = 117,
                            Address = "Tunalı Hilmi",
                            CategoryId = 13,
                            Name = "Kahve Dünyası",
                            TelNo = "03125678901"
                        },
                        new
                        {
                            Id = 118,
                            Address = "Ankara Üniversitesi",
                            CategoryId = 9,
                            Name = "Pideci Baba",
                            TelNo = "03123456789"
                        },
                        new
                        {
                            Id = 119,
                            Address = "Yıldırım Beyazıt Üniversitesi",
                            CategoryId = 10,
                            Name = "Kahvaltı Bahçesi",
                            TelNo = "03127894567"
                        },
                        new
                        {
                            Id = 120,
                            Address = "Cebeci",
                            CategoryId = 11,
                            Name = "Lahmacun Dükkanı",
                            TelNo = "03125678912"
                        });
                });

            modelBuilder.Entity("YemekDünyasi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UsersTable");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Batıkent",
                            Email = "Durayse@gmail.com",
                            Name = "Ayşe",
                            Surname = "Duran",
                            TelNo = "05434346578"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Ümitköy",
                            Email = "Durayse@gmail.com",
                            Name = "Ai",
                            Surname = "Kaşcı",
                            TelNo = "05434346578"
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Çamlıca",
                            Email = "ahmet1987@gmail.com",
                            Name = "Ahmet",
                            Surname = "Satır",
                            TelNo = "05434346579"
                        },
                        new
                        {
                            Id = 4,
                            Adress = "Sıhiyye",
                            Email = "12345@gmail.com",
                            Name = "Kemal",
                            Surname = "Kuru",
                            TelNo = "05434346574"
                        },
                        new
                        {
                            Id = 5,
                            Adress = "Ulus",
                            Email = "sk1234@gmail.com",
                            Name = "Selvi",
                            Surname = "Kara",
                            TelNo = "05434346573"
                        },
                        new
                        {
                            Id = 6,
                            Adress = "Etimesgut",
                            Email = "2Mel@gmail.com",
                            Name = "Melih",
                            Surname = "Mutlu",
                            TelNo = "05434346575"
                        },
                        new
                        {
                            Id = 7,
                            Adress = "Bahçelievler",
                            Email = "taskadir@gmail.com",
                            Name = "Kadir",
                            Surname = "Taş",
                            TelNo = "05434346570"
                        },
                        new
                        {
                            Id = 8,
                            Adress = "Emek",
                            Email = "elifs@gmail.com",
                            Name = "Elif",
                            Surname = "Salkım",
                            TelNo = "05434346572"
                        },
                        new
                        {
                            Id = 9,
                            Adress = "Mamak",
                            Email = "daylin@gmail.com",
                            Name = "aylin",
                            Surname = "Durmuş",
                            TelNo = "05434346571"
                        },
                        new
                        {
                            Id = 10,
                            Adress = "Batımerkez",
                            Email = "kalden@gmail.com",
                            Name = "Deniz",
                            Surname = "Kaleci",
                            TelNo = "05434346576"
                        });
                });

            modelBuilder.Entity("YemekDünyasi.Models.UserSepet", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserSepetTable");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Order", b =>
                {
                    b.HasOne("YemekDünyasi.Models.Restaurant", null)
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId");

                    b.HasOne("YemekDünyasi.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("YemekDünyasi.Models.OrderItem", b =>
                {
                    b.HasOne("YemekDünyasi.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YemekDünyasi.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Product", b =>
                {
                    b.HasOne("YemekDünyasi.Models.Restaurant", "Restaurant")
                        .WithMany("Products")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Restaurant", b =>
                {
                    b.HasOne("YemekDünyasi.Models.Category", "Category")
                        .WithMany("Restaurants")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("YemekDünyasi.Models.UserSepet", b =>
                {
                    b.HasOne("YemekDünyasi.Models.Product", "Product")
                        .WithMany("UserCarts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YemekDünyasi.Models.User", "User")
                        .WithMany("UserSepets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Category", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("UserCarts");
                });

            modelBuilder.Entity("YemekDünyasi.Models.Restaurant", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("YemekDünyasi.Models.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("UserSepets");
                });
#pragma warning restore 612, 618
        }
    }
}