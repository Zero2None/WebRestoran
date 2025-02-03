﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebRestoran.Data;

#nullable disable

namespace WebRestoran.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250203161648_revertContext_onDelete_cascade")]
    partial class revertContext_onDelete_cascade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WebRestoran.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("WebRestoran.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Predjelo"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Glavno jelo"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Juha"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Salata"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Desert"
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Piće"
                        });
                });

            modelBuilder.Entity("WebRestoran.Models.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageThumbnailUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("FoodId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Food");

                    b.HasData(
                        new
                        {
                            FoodId = 1,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Piletinom i Rižom",
                            FoodName = "Wok Piletina Riža",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.3m,
                            Stock = 37
                        },
                        new
                        {
                            FoodId = 2,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Piletinom i Tjesteninom",
                            FoodName = "Wok Piletina Tjestenina",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.6m,
                            Stock = 43
                        },
                        new
                        {
                            FoodId = 3,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Piletinom i Staklenim rezancima",
                            FoodName = "Wok Piletina Stakleni rezanci",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.9m,
                            Stock = 53
                        },
                        new
                        {
                            FoodId = 4,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Junetinom i Rižom",
                            FoodName = "Wok Junetina Riža",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 12.5m,
                            Stock = 25
                        },
                        new
                        {
                            FoodId = 5,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Junetinom i Tjesteninom",
                            FoodName = "Wok Junetina Tjestenina",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 12.9m,
                            Stock = 38
                        },
                        new
                        {
                            FoodId = 6,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Junetinom i Staklenim rezancima",
                            FoodName = "Wok Junetina Stakleni rezanci",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 13.1m,
                            Stock = 55
                        },
                        new
                        {
                            FoodId = 7,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Svinjetinom i Rižom",
                            FoodName = "Wok Svinjetina Riža",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.5m,
                            Stock = 37
                        },
                        new
                        {
                            FoodId = 8,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Svinjetinom i Tjesteninom",
                            FoodName = "Wok Svinjetina Tjestenina",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.7m,
                            Stock = 45
                        },
                        new
                        {
                            FoodId = 9,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Svinjetinom i Staklenim rezancima",
                            FoodName = "Wok Svinjetina Stakleni rezanci",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 11.5m,
                            Stock = 28
                        },
                        new
                        {
                            FoodId = 10,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Morskim plodovima i Rižom",
                            FoodName = "Wok Morski plodovi Riža",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 13.5m,
                            Stock = 42
                        },
                        new
                        {
                            FoodId = 11,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Morskim plodovima i Tjesteninom",
                            FoodName = "Wok Morski plodovi Tjestenina",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 13.7m,
                            Stock = 37
                        },
                        new
                        {
                            FoodId = 12,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Morskim plodovima i Staklenim rezancima",
                            FoodName = "Wok Morski plodovi Stakleni rezanci",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 13.9m,
                            Stock = 34
                        },
                        new
                        {
                            FoodId = 13,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Tofu i Rižom",
                            FoodName = "Wok Tofu Riža",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.5m,
                            Stock = 28
                        },
                        new
                        {
                            FoodId = 14,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Tofu i Tjesteninom",
                            FoodName = "Wok Tofu Tjestenina",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.3m,
                            Stock = 23
                        },
                        new
                        {
                            FoodId = 15,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Tofu i Staklenim rezancima",
                            FoodName = "Wok Tofu Stakleni rezanci",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 10.8m,
                            Stock = 36
                        },
                        new
                        {
                            FoodId = 16,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Povrćem i Rižom",
                            FoodName = "Wok Povrće Riža",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 8.5m,
                            Stock = 17
                        },
                        new
                        {
                            FoodId = 17,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Povrćem i Tjesteninom",
                            FoodName = "Wok Povrće Tjestenina",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 8.5m,
                            Stock = 43
                        },
                        new
                        {
                            FoodId = 18,
                            CategoryId = 1,
                            Description = "Ukusni wok sa Povrćem i Staklenim rezancima",
                            FoodName = "Wok Povrće Stakleni rezanci",
                            ImageUrl = "https://www.placeholder.com/333",
                            Price = 8.5m,
                            Stock = 36
                        });
                });

            modelBuilder.Entity("WebRestoran.Models.FoodIngredient", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("IngredientId")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "IngredientId");

                    b.HasIndex("IngredientId");

                    b.ToTable("FoodIngredients");

                    b.HasData(
                        new
                        {
                            FoodId = 1,
                            IngredientId = 1
                        },
                        new
                        {
                            FoodId = 1,
                            IngredientId = 7
                        },
                        new
                        {
                            FoodId = 2,
                            IngredientId = 1
                        },
                        new
                        {
                            FoodId = 2,
                            IngredientId = 8
                        },
                        new
                        {
                            FoodId = 3,
                            IngredientId = 1
                        },
                        new
                        {
                            FoodId = 3,
                            IngredientId = 9
                        },
                        new
                        {
                            FoodId = 4,
                            IngredientId = 2
                        },
                        new
                        {
                            FoodId = 4,
                            IngredientId = 7
                        },
                        new
                        {
                            FoodId = 5,
                            IngredientId = 2
                        },
                        new
                        {
                            FoodId = 5,
                            IngredientId = 8
                        },
                        new
                        {
                            FoodId = 6,
                            IngredientId = 2
                        },
                        new
                        {
                            FoodId = 6,
                            IngredientId = 9
                        },
                        new
                        {
                            FoodId = 7,
                            IngredientId = 3
                        },
                        new
                        {
                            FoodId = 7,
                            IngredientId = 7
                        },
                        new
                        {
                            FoodId = 8,
                            IngredientId = 3
                        },
                        new
                        {
                            FoodId = 8,
                            IngredientId = 8
                        },
                        new
                        {
                            FoodId = 9,
                            IngredientId = 3
                        },
                        new
                        {
                            FoodId = 9,
                            IngredientId = 9
                        },
                        new
                        {
                            FoodId = 10,
                            IngredientId = 4
                        },
                        new
                        {
                            FoodId = 10,
                            IngredientId = 7
                        },
                        new
                        {
                            FoodId = 11,
                            IngredientId = 4
                        },
                        new
                        {
                            FoodId = 11,
                            IngredientId = 8
                        },
                        new
                        {
                            FoodId = 12,
                            IngredientId = 4
                        },
                        new
                        {
                            FoodId = 12,
                            IngredientId = 9
                        },
                        new
                        {
                            FoodId = 13,
                            IngredientId = 5
                        },
                        new
                        {
                            FoodId = 13,
                            IngredientId = 7
                        },
                        new
                        {
                            FoodId = 14,
                            IngredientId = 5
                        },
                        new
                        {
                            FoodId = 14,
                            IngredientId = 8
                        },
                        new
                        {
                            FoodId = 15,
                            IngredientId = 5
                        },
                        new
                        {
                            FoodId = 15,
                            IngredientId = 9
                        },
                        new
                        {
                            FoodId = 16,
                            IngredientId = 6
                        },
                        new
                        {
                            FoodId = 16,
                            IngredientId = 7
                        },
                        new
                        {
                            FoodId = 17,
                            IngredientId = 6
                        },
                        new
                        {
                            FoodId = 17,
                            IngredientId = 8
                        },
                        new
                        {
                            FoodId = 18,
                            IngredientId = 6
                        },
                        new
                        {
                            FoodId = 18,
                            IngredientId = 9
                        });
                });

            modelBuilder.Entity("WebRestoran.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientId"));

                    b.Property<string>("IngredientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            IngredientId = 1,
                            IngredientName = "Piletina"
                        },
                        new
                        {
                            IngredientId = 2,
                            IngredientName = "Junetina"
                        },
                        new
                        {
                            IngredientId = 3,
                            IngredientName = "Svinjetina"
                        },
                        new
                        {
                            IngredientId = 4,
                            IngredientName = "Morski plodovi"
                        },
                        new
                        {
                            IngredientId = 5,
                            IngredientName = "Tofu"
                        },
                        new
                        {
                            IngredientId = 6,
                            IngredientName = "Povrće"
                        },
                        new
                        {
                            IngredientId = 7,
                            IngredientName = "Riža"
                        },
                        new
                        {
                            IngredientId = 8,
                            IngredientName = "Tjestenina"
                        },
                        new
                        {
                            IngredientId = 9,
                            IngredientName = "Stakleni rezanci"
                        });
                });

            modelBuilder.Entity("WebRestoran.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalAmmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebRestoran.Models.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemId"));

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemId");

                    b.HasIndex("FoodId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebRestoran.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebRestoran.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRestoran.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebRestoran.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebRestoran.Models.Food", b =>
                {
                    b.HasOne("WebRestoran.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebRestoran.Models.FoodIngredient", b =>
                {
                    b.HasOne("WebRestoran.Models.Food", "Food")
                        .WithMany("FoodIngredients")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRestoran.Models.Ingredient", "Ingredient")
                        .WithMany("FoodIngredients")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("WebRestoran.Models.Order", b =>
                {
                    b.HasOne("WebRestoran.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebRestoran.Models.OrderItem", b =>
                {
                    b.HasOne("WebRestoran.Models.Food", "Food")
                        .WithMany("OrderItems")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRestoran.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("WebRestoran.Models.ApplicationUser", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("WebRestoran.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebRestoran.Models.Food", b =>
                {
                    b.Navigation("FoodIngredients");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("WebRestoran.Models.Ingredient", b =>
                {
                    b.Navigation("FoodIngredients");
                });

            modelBuilder.Entity("WebRestoran.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
