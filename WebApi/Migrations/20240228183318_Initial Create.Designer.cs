﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

#nullable disable

namespace WebApi.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20240228183318_Initial Create")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApi.Models.DbItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DbItems");
                });

            modelBuilder.Entity("WebApi.Models.DbItemsUnits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DbItemsId")
                        .HasColumnType("int");

                    b.Property<int?>("DbUnitsId")
                        .HasColumnType("int");

                    b.Property<int>("IdItem")
                        .HasColumnType("int");

                    b.Property<int>("IdUnit")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("DbItemsId");

                    b.HasIndex("DbUnitsId");

                    b.ToTable("DbItemsUnits");
                });

            modelBuilder.Entity("WebApi.Models.DbUnits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("DbUnits");
                });

            modelBuilder.Entity("WebApi.Models.DbItemsUnits", b =>
                {
                    b.HasOne("WebApi.Models.DbItems", "DbItems")
                        .WithMany()
                        .HasForeignKey("DbItemsId");

                    b.HasOne("WebApi.Models.DbUnits", "DbUnits")
                        .WithMany()
                        .HasForeignKey("DbUnitsId");

                    b.Navigation("DbItems");

                    b.Navigation("DbUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
