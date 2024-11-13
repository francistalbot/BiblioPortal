﻿// <auto-generated />
using System;
using BiblioPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BiblioPortal.Migrations
{
    [DbContext(typeof(BiblioDbContext))]
    partial class BiblioDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BiblioPortal.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DateOfBirth")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("BiblioPortal.Models.Location", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int")
                        .HasColumnOrder(0);

                    b.Property<int>("OutilId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnOrder(2);

                    b.HasKey("ClientId", "OutilId", "Date");

                    b.HasIndex("OutilId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("BiblioPortal.Models.Outil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Outils");
                });

            modelBuilder.Entity("BiblioPortal.Models.Location", b =>
                {
                    b.HasOne("BiblioPortal.Models.Client", "Client")
                        .WithMany("Locations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BiblioPortal.Models.Outil", "Outil")
                        .WithMany("Locations")
                        .HasForeignKey("OutilId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Outil");
                });

            modelBuilder.Entity("BiblioPortal.Models.Client", b =>
                {
                    b.Navigation("Locations");
                });

            modelBuilder.Entity("BiblioPortal.Models.Outil", b =>
                {
                    b.Navigation("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}
