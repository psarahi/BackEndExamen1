﻿// <auto-generated />
using System;
using BackEndExamen1.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Examen1_Bonnie.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0");

            modelBuilder.Entity("BackEndExamen1.Models.Operacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("Resultado")
                        .HasColumnType("TEXT");

                    b.Property<string>("expresion")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Historial");
                });
#pragma warning restore 612, 618
        }
    }
}
