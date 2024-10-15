﻿// <auto-generated />
using System;
using Ex02_SettingUpWorkWithData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ex02_SettingUpWorkWithData.Migrations
{
    [DbContext(typeof(CreditContextClass))]
    [Migration("20241015210006_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ex02_SettingUpWorkWithData.Models.BidClass", b =>
                {
                    b.Property<int>("BidClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidClassId"));

                    b.Property<string>("CreditHead")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("bidDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BidClassId");

                    b.ToTable("Bids");
                });

            modelBuilder.Entity("Ex02_SettingUpWorkWithData.Models.CreditClass", b =>
                {
                    b.Property<int>("CreditClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CreditClassId"));

                    b.Property<string>("Head")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<int>("Procent")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.HasKey("CreditClassId");

                    b.ToTable("Credits");
                });
#pragma warning restore 612, 618
        }
    }
}
