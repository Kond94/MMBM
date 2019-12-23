﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using mmbm.Persistence;

namespace mmbm.Migrations
{
    [DbContext(typeof(MMBMDbContext))]
    partial class MMBMDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("mmbm.Core.Models.Branch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("mmbm.Core.Models.ConsolidatedReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ConsolidatedReports");
                });

            modelBuilder.Entity("mmbm.Core.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("mmbm.Core.Models.MobileMoneyReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<double>("ClosingCash")
                        .HasColumnType("double precision");

                    b.Property<double>("ClosingEvalue")
                        .HasColumnType("double precision");

                    b.Property<int>("ConsolidatedReportId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<double>("OpeningCash")
                        .HasColumnType("double precision");

                    b.Property<double>("OpeningEvalue")
                        .HasColumnType("double precision");

                    b.Property<double?>("SentInCash")
                        .HasColumnType("double precision");

                    b.Property<double?>("SentInEvalue")
                        .HasColumnType("double precision");

                    b.Property<double?>("SentOutCash")
                        .HasColumnType("double precision");

                    b.Property<double?>("SentOutEvalue")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("ConsolidatedReportId")
                        .IsUnique();

                    b.ToTable("MobileMoneyReports");
                });

            modelBuilder.Entity("mmbm.Core.Models.Shop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("EmployeeId")
                        .IsUnique();

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("mmbm.Core.Models.Simcard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BranchId")
                        .HasColumnType("integer");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Simcards");
                });

            modelBuilder.Entity("mmbm.Core.Models.ConsolidatedReport", b =>
                {
                    b.HasOne("mmbm.Core.Models.Employee", "Employee")
                        .WithMany("Reports")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("mmbm.Core.Models.Employee", b =>
                {
                    b.HasOne("mmbm.Core.Models.Branch", "Branch")
                        .WithMany("Employees")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mmbm.Core.Models.MobileMoneyReport", b =>
                {
                    b.HasOne("mmbm.Core.Models.ConsolidatedReport", "ConsolidatedReport")
                        .WithOne("MobileMoneyReport")
                        .HasForeignKey("mmbm.Core.Models.MobileMoneyReport", "ConsolidatedReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("mmbm.Core.Models.Shop", b =>
                {
                    b.HasOne("mmbm.Core.Models.Branch", "Branch")
                        .WithMany("Shops")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mmbm.Core.Models.Employee", "Employee")
                        .WithOne("Shop")
                        .HasForeignKey("mmbm.Core.Models.Shop", "EmployeeId");
                });

            modelBuilder.Entity("mmbm.Core.Models.Simcard", b =>
                {
                    b.HasOne("mmbm.Core.Models.Branch", "Branch")
                        .WithMany("Simcards")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mmbm.Core.Models.Employee", "Employee")
                        .WithMany("Simcards")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}