﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using la_mia_pizzeria_static;

#nullable disable

namespace la_mia_pizzeria_static.Migrations
{
    [DbContext(typeof(PizzeriaContext))]
    [Migration("20230514225732_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IngredientPizza", b =>
                {
                    b.Property<long>("IngredientsIngredientId")
                        .HasColumnType("bigint");

                    b.Property<long>("PizzasPizzaId")
                        .HasColumnType("bigint");

                    b.HasKey("IngredientsIngredientId", "PizzasPizzaId");

                    b.HasIndex("PizzasPizzaId");

                    b.ToTable("IngredientPizza");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Category", b =>
                {
                    b.Property<long>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Ingredient", b =>
                {
                    b.Property<long>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IngredientId"));

                    b.Property<bool>("Allergen")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IngredientId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Pizza", b =>
                {
                    b.Property<long>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PizzaId"));

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("PizzaId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PizzaId")
                        .IsUnique();

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("IngredientPizza", b =>
                {
                    b.HasOne("la_mia_pizzeria_static.Models.Ingredient", null)
                        .WithMany()
                        .HasForeignKey("IngredientsIngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("la_mia_pizzeria_static.Models.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasPizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Pizza", b =>
                {
                    b.HasOne("la_mia_pizzeria_static.Models.Category", "Category")
                        .WithMany("Pizzas")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("la_mia_pizzeria_static.Models.Category", b =>
                {
                    b.Navigation("Pizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
