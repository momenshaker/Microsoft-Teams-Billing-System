﻿// <auto-generated />
using System;
using BillingSystemV4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BillingSystemV4.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20200712093353_AddServers")]
    partial class AddServers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BillingSystemV4.Models.RecordsTable", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalleeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CalleeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CalleeNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CalleeTanent")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CallerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CallerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CallerNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CallerTanent")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IncomingPhone")
                        .HasColumnType("bit");

                    b.Property<bool>("Phone")
                        .HasColumnType("bit");

                    b.Property<Guid>("RecoredId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReflexiveIPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionCalleePlatform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionCalleeProductFamily")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionCallerPlatform")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SessionCallerProductFamily")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("TotalCost")
                        .HasColumnType("float");

                    b.Property<double>("TotalTime")
                        .HasColumnType("float");

                    b.Property<string>("dnsSuffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("endDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset>("startDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("recordsTables");
                });

            modelBuilder.Entity("BillingSystemV4.Models.Servers", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerIP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("BillingSystemV4.Models.SubPhones", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("CostPerMinute")
                        .HasColumnType("float");

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<bool>("PerMinute")
                        .HasColumnType("bit");

                    b.Property<bool>("PerSecond")
                        .HasColumnType("bit");

                    b.Property<string>("ProviderName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("phonecode")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("SubPhones");
                });

            modelBuilder.Entity("BillingSystemV4.Models.SubscriptionChecker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CheckedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ValidateToken")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionChecker");
                });

            modelBuilder.Entity("BillingSystemV4.Models.country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("CostPerMinute")
                        .HasColumnType("float");

                    b.Property<bool>("PerMinute")
                        .HasColumnType("bit");

                    b.Property<bool>("PerSecond")
                        .HasColumnType("bit");

                    b.Property<bool>("SubPhones")
                        .HasColumnType("bit");

                    b.Property<string>("countryname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("iso3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nicename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("numcode")
                        .HasColumnType("int");

                    b.Property<int?>("phonecode")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("country");
                });
#pragma warning restore 612, 618
        }
    }
}
