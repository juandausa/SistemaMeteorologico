﻿// <auto-generated />
using HwEFCoreWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HwEFCoreWebAPI.Migrations
{
    [DbContext(typeof(ForecastContext))]
    partial class ForecastContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Entities.WeatherControl.Forecast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Day")
                        .HasColumnType("INTEGER");

                    b.Property<double>("RainfallIntensity")
                        .HasColumnType("REAL");

                    b.Property<int>("Weather")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Forecasts");
                });
#pragma warning restore 612, 618
        }
    }
}