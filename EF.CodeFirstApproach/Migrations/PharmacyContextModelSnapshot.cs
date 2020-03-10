﻿// <auto-generated />
using EF.CodeFirstApproach.DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF.CodeFirstApproach.Migrations
{
    [DbContext(typeof(PharmacyContext))]
    partial class PharmacyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF.CodeFirstApproach.DomainModels.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Instruction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("EF.CodeFirstApproach.DomainModels.MedicinePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MedicineId")
                        .HasColumnType("int");

                    b.Property<int>("PharmacyAddressId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("MedicineId");

                    b.HasIndex("PharmacyAddressId");

                    b.ToTable("MedicinePrices");
                });

            modelBuilder.Entity("EF.CodeFirstApproach.DomainModels.PharmacyAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PharmacyNetworkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyNetworkId");

                    b.ToTable("PharmacyAddresses");
                });

            modelBuilder.Entity("EF.CodeFirstApproach.DomainModels.PharmacyNetwork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PharmacyNetworks");
                });

            modelBuilder.Entity("EF.CodeFirstApproach.DomainModels.MedicinePrice", b =>
                {
                    b.HasOne("EF.CodeFirstApproach.DomainModels.Medicine", "Medicine")
                        .WithMany("MedicinePrices")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF.CodeFirstApproach.DomainModels.PharmacyAddress", "PharmacyAddress")
                        .WithMany("MedicinePrices")
                        .HasForeignKey("PharmacyAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EF.CodeFirstApproach.DomainModels.PharmacyAddress", b =>
                {
                    b.HasOne("EF.CodeFirstApproach.DomainModels.PharmacyNetwork", "PharmacyNetwork")
                        .WithMany("Addresses")
                        .HasForeignKey("PharmacyNetworkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
