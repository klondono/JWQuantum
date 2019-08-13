﻿// <auto-generated />
using System;
using JWQuantum.MobileAppService.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JWQuantum.MobileAppService.Migrations
{
    [DbContext(typeof(JWQuantumContext))]
    [Migration("20190813012922_NewMigration")]
    partial class NewMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JWQuantum.MobileAppService.DbModels.JWQuantumContext+Action", b =>
                {
                    b.Property<int>("ActionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName");

                    b.Property<int>("PersonId");

                    b.HasKey("ActionId");

                    b.HasIndex("PersonId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("JWQuantum.MobileAppService.DbModels.JWQuantumContext+Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("XCoord");

                    b.Property<decimal>("YCoord");

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("JWQuantum.MobileAppService.DbModels.JWQuantumContext+Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AddressId");

                    b.Property<string>("FirstName");

                    b.Property<bool?>("IsAuxilaryPioneer");

                    b.Property<bool?>("IsElder");

                    b.Property<bool?>("IsMinisterialServant");

                    b.Property<bool?>("IsPublisher");

                    b.Property<bool?>("IsRegularPioneer");

                    b.Property<bool?>("IsSpecialPioneer");

                    b.Property<string>("LastName");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("JWQuantum.MobileAppService.DbModels.JWQuantumContext+Action", b =>
                {
                    b.HasOne("JWQuantum.MobileAppService.DbModels.JWQuantumContext+Person", "Person")
                        .WithMany("Actions")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JWQuantum.MobileAppService.DbModels.JWQuantumContext+Person", b =>
                {
                    b.HasOne("JWQuantum.MobileAppService.DbModels.JWQuantumContext+Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
