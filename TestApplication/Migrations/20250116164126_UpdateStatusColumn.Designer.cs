﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestApplication.DataBase.Configurations;

#nullable disable

namespace TestApplication.Migrations
{
    [DbContext(typeof(CrashTrackerDbContext))]
    [Migration("20250116164126_UpdateStatusColumn")]
    partial class UpdateStatusColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestApplication.DataBase.Entities.CrashEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<Guid>("StatusId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Crash");
                });

            modelBuilder.Entity("TestApplication.DataBase.Entities.OperationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CrashId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CrashId");

                    b.ToTable("Operation");
                });

            modelBuilder.Entity("TestApplication.DataBase.Entities.StatusEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("TestApplication.DataBase.Entities.CrashEntity", b =>
                {
                    b.HasOne("TestApplication.DataBase.Entities.StatusEntity", null)
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("TestApplication.DataBase.Entities.OperationEntity", b =>
                {
                    b.HasOne("TestApplication.DataBase.Entities.CrashEntity", null)
                        .WithMany("Operations")
                        .HasForeignKey("CrashId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestApplication.DataBase.Entities.CrashEntity", b =>
                {
                    b.Navigation("Operations");
                });
#pragma warning restore 612, 618
        }
    }
}
