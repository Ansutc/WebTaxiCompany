﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebTaxiCompany.Data;

namespace WebTaxiCompany.Migrations
{
    [DbContext(typeof(TaxiCompanyContext))]
    partial class TaxiCompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebTaxiCompany.Models.AddService", b =>
                {
                    b.Property<int>("AddServiceKey")
                        .HasColumnType("INT");

                    b.Property<int>("Cost")
                        .HasColumnType("INT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.HasKey("AddServiceKey");

                    b.ToTable("AddService");
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Brand", b =>
                {
                    b.Property<int>("BrandKey")
                        .HasColumnType("INT");

                    b.Property<int>("Cost")
                        .HasColumnType("INT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Specifications")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Specificity")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.HasKey("BrandKey");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Call", b =>
                {
                    b.Property<int>("NumKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddServiceKey")
                        .HasColumnType("INT");

                    b.Property<int>("CarKey")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("DATE");

                    b.Property<int>("EmployeeKey")
                        .HasColumnType("INT");

                    b.Property<int>("Number")
                        .HasColumnType("INT");

                    b.Property<int>("RateKey")
                        .HasColumnType("INT");

                    b.Property<DateTime>("Time")
                        .HasColumnType("DATETIME");

                    b.Property<string>("WhereFrom")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("WhereTo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.HasKey("NumKey");

                    b.HasIndex("AddServiceKey");

                    b.HasIndex("CarKey");

                    b.HasIndex("EmployeeKey");

                    b.HasIndex("RateKey");

                    b.ToTable("Call");
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Car", b =>
                {
                    b.Property<int>("CarKey")
                        .HasColumnType("INT");

                    b.Property<int>("BodNumber")
                        .HasColumnType("INT");

                    b.Property<int>("BrandKey")
                        .HasColumnType("INT");

                    b.Property<int>("EmployeeKey")
                        .HasColumnType("INT");

                    b.Property<int>("EngineNumber")
                        .HasColumnType("INT");

                    b.Property<DateTime>("MaintenanceDate")
                        .HasColumnType("DATE");

                    b.Property<int>("MechanicKeyEmployeeKey")
                        .HasColumnType("INT");

                    b.Property<int>("Mileage")
                        .HasColumnType("INT");

                    b.Property<int>("RegistrationNumber")
                        .HasColumnType("INT");

                    b.Property<string>("SpecialMarks")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<DateTime>("YearOfIssue")
                        .HasColumnType("DATE");

                    b.HasKey("CarKey");

                    b.HasIndex("BrandKey");

                    b.HasIndex("EmployeeKey");

                    b.HasIndex("MechanicKeyEmployeeKey");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeKey")
                        .HasColumnType("INT");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DATE");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("Number")
                        .HasColumnType("INT");

                    b.Property<int>("Passport")
                        .HasColumnType("INT");

                    b.Property<int>("PositionKey")
                        .HasColumnType("INT");

                    b.HasKey("EmployeeKey");

                    b.HasIndex("PositionKey");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Position", b =>
                {
                    b.Property<int>("PositionKey")
                        .HasColumnType("INT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Requirement")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Responsibility")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<int>("Salary")
                        .HasColumnType("INT");

                    b.HasKey("PositionKey");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Rate", b =>
                {
                    b.Property<int>("RateKey")
                        .HasColumnType("INT");

                    b.Property<int>("Cost")
                        .HasColumnType("INT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR (255)");

                    b.HasKey("RateKey");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Call", b =>
                {
                    b.HasOne("WebTaxiCompany.Models.AddService", "AddServiceKeyNavigation")
                        .WithMany()
                        .HasForeignKey("AddServiceKey")
                        .IsRequired();

                    b.HasOne("WebTaxiCompany.Models.Car", "CarKeyNavigation")
                        .WithMany()
                        .HasForeignKey("CarKey")
                        .IsRequired();

                    b.HasOne("WebTaxiCompany.Models.Employee", "EmployeeKeyNavigation")
                        .WithMany()
                        .HasForeignKey("EmployeeKey")
                        .IsRequired();

                    b.HasOne("WebTaxiCompany.Models.Rate", "RateKeyNavigation")
                        .WithMany()
                        .HasForeignKey("RateKey")
                        .IsRequired();
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Car", b =>
                {
                    b.HasOne("WebTaxiCompany.Models.Brand", "BrandKeyNavigation")
                        .WithMany("Car")
                        .HasForeignKey("BrandKey")
                        .IsRequired();

                    b.HasOne("WebTaxiCompany.Models.Employee", "EmployeeKeyNavigation")
                        .WithMany("CarEmployeeKeyNavigation")
                        .HasForeignKey("EmployeeKey")
                        .IsRequired();

                    b.HasOne("WebTaxiCompany.Models.Employee", "MechanicKeyEmployeeKeyNavigation")
                        .WithMany("CarMechanicKeyEmployeeKeyNavigation")
                        .HasForeignKey("MechanicKeyEmployeeKey")
                        .IsRequired();
                });

            modelBuilder.Entity("WebTaxiCompany.Models.Employee", b =>
                {
                    b.HasOne("WebTaxiCompany.Models.Position", "PositionKeyNavigation")
                        .WithMany("Employee")
                        .HasForeignKey("PositionKey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}