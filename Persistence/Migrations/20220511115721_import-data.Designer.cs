// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220511115721_import-data")]
    partial class importdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.ExcerciseEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("IdEvent")
                        .HasColumnType("int");

                    b.Property<int>("IdMachine")
                        .HasColumnType("int");

                    b.Property<int>("RefId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ExcerciseEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
