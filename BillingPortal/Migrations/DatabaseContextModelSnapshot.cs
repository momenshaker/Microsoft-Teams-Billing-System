﻿// <auto-generated />
using System;
using BillingPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BillingPortal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("BillingPortal.Models.CompanyServers", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerIP")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerName")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("CompanyServers");
                });

            modelBuilder.Entity("BillingPortal.Models.ExportedFiles", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ExportedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExportedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ExportedFiles");
                });

            modelBuilder.Entity("BillingPortal.Models.RecordsTable", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CalleeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CalleeName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CalleeNumber")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CalleeTanent")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CallerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CallerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CallerNumber")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CallerTanent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IncomingPhone")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Phone")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RecoredId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReflexiveIPAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionCalleePlatform")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionCalleeProductFamily")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionCallerPlatform")
                        .HasColumnType("TEXT");

                    b.Property<string>("SessionCallerProductFamily")
                        .HasColumnType("TEXT");

                    b.Property<double?>("TotalCost")
                        .HasColumnType("REAL");

                    b.Property<double>("TotalTime")
                        .HasColumnType("REAL");

                    b.Property<string>("dnsSuffix")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("endDateTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTimeOffset>("startDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("type")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("recordsTables");
                });

            modelBuilder.Entity("BillingPortal.Models.SubPhones", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<double?>("CostPerMinute")
                        .HasColumnType("REAL");

                    b.Property<int>("CountryID")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PerMinute")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PerSecond")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProviderName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Server")
                        .HasColumnType("TEXT");

                    b.Property<string>("ServerName")
                        .HasColumnType("TEXT");

                    b.Property<int?>("phonecode")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("SubPhones");
                });

            modelBuilder.Entity("BillingPortal.Models.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AID")
                        .HasColumnType("TEXT");

                    b.Property<string>("OID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sec")
                        .HasColumnType("TEXT");

                    b.Property<string>("TID")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings");
                });

            modelBuilder.Entity("BillingPortal.Models.country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("CostPerMinute")
                        .HasColumnType("REAL");

                    b.Property<bool>("PerMinute")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("PerSecond")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SubPhones")
                        .HasColumnType("INTEGER");

                    b.Property<string>("countryname")
                        .HasColumnType("TEXT");

                    b.Property<string>("iso")
                        .HasColumnType("TEXT");

                    b.Property<string>("iso3")
                        .HasColumnType("TEXT");

                    b.Property<string>("nicename")
                        .HasColumnType("TEXT");

                    b.Property<int?>("numcode")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("phonecode")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("country");
                });
#pragma warning restore 612, 618
        }
    }
}
