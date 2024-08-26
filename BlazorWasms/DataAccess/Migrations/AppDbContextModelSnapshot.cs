﻿// <auto-generated />
using System;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Business.Entities.Horario", b =>
                {
                    b.Property<int>("IdHorario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdHorario"));

                    b.Property<DateTime>("FechaYHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPelicula")
                        .HasColumnType("int");

                    b.Property<int>("IdSala")
                        .HasColumnType("int");

                    b.HasKey("IdHorario");

                    b.HasIndex("IdPelicula");

                    b.HasIndex("IdSala");

                    b.ToTable("Horarios");
                });

            modelBuilder.Entity("Business.Entities.Pelicula", b =>
                {
                    b.Property<int>("IdPelicula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPelicula"));

                    b.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DuracionMin")
                        .HasColumnType("int");

                    b.Property<string>("NombrePelicula")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPelicula");

                    b.ToTable("Peliculas");
                });

            modelBuilder.Entity("Business.Entities.Sala", b =>
                {
                    b.Property<int>("IdSala")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSala"));

                    b.Property<string>("CodigoSala")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreSala")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSala");

                    b.ToTable("Salas");
                });

            modelBuilder.Entity("Business.Entities.Horario", b =>
                {
                    b.HasOne("Business.Entities.Pelicula", "Pelicula")
                        .WithMany("Horarios")
                        .HasForeignKey("IdPelicula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Business.Entities.Sala", "Sala")
                        .WithMany("Horarios")
                        .HasForeignKey("IdSala")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Business.Entities.Pelicula", b =>
                {
                    b.Navigation("Horarios");
                });

            modelBuilder.Entity("Business.Entities.Sala", b =>
                {
                    b.Navigation("Horarios");
                });
#pragma warning restore 612, 618
        }
    }
}
