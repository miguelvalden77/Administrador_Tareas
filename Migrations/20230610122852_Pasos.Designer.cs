﻿// <auto-generated />
using System;
using Administrador_Tareas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Administrador_Tareas.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230610122852_Pasos")]
    partial class Pasos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Administrador_Tareas.Entidades.Paso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<bool>("Realizado")
                        .HasColumnType("bit");

                    b.Property<int>("TareaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TareaId");

                    b.ToTable("Pasos");
                });

            modelBuilder.Entity("Administrador_Tareas.Entidades.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("Administrador_Tareas.Entidades.Paso", b =>
                {
                    b.HasOne("Administrador_Tareas.Entidades.Tarea", "Tarea")
                        .WithMany("Pasos")
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tarea");
                });

            modelBuilder.Entity("Administrador_Tareas.Entidades.Tarea", b =>
                {
                    b.Navigation("Pasos");
                });
#pragma warning restore 612, 618
        }
    }
}
