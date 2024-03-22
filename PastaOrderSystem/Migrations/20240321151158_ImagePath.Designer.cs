﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApi.Context;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240321151158_ImagePath")]
    partial class ImagePath
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApi.Entity.Beverage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Beverage");
                });

            modelBuilder.Entity("WebApi.Entity.ExtraIngredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ExtraIngredient");
                });

            modelBuilder.Entity("WebApi.Entity.Junction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("BeverageId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ExtraIngredientId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PastaId")
                        .HasColumnType("uuid");

                    b.Property<int?>("PastaNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BeverageId");

                    b.HasIndex("ExtraIngredientId");

                    b.HasIndex("OrderId");

                    b.HasIndex("PastaId");

                    b.ToTable("Junction");
                });

            modelBuilder.Entity("WebApi.Entity.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("WebApi.Entity.Pasta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Pasta");
                });

            modelBuilder.Entity("WebApi.Entity.Junction", b =>
                {
                    b.HasOne("WebApi.Entity.Beverage", "Beverage")
                        .WithMany()
                        .HasForeignKey("BeverageId");

                    b.HasOne("WebApi.Entity.ExtraIngredient", "ExtraIngredient")
                        .WithMany()
                        .HasForeignKey("ExtraIngredientId");

                    b.HasOne("WebApi.Entity.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId");

                    b.HasOne("WebApi.Entity.Pasta", "Pasta")
                        .WithMany()
                        .HasForeignKey("PastaId");

                    b.Navigation("Beverage");

                    b.Navigation("ExtraIngredient");

                    b.Navigation("Order");

                    b.Navigation("Pasta");
                });
#pragma warning restore 612, 618
        }
    }
}