﻿// <auto-generated />
using System;
using Metrics.Services.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Metrics.Services.Infrastructure.Migrations
{
    [DbContext(typeof(MetricsDbContext))]
    partial class MetricsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Metrics.Services.Domain.Entities.IngestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<long>("EndDate")
                        .HasMaxLength(11)
                        .HasColumnType("bigint")
                        .HasColumnName("END_DATE");

                    b.Property<long>("InitDate")
                        .HasMaxLength(11)
                        .HasColumnType("bigint")
                        .HasColumnName("INIT_DATE");

                    b.Property<int>("MachineId")
                        .HasColumnType("int")
                        .HasColumnName("ID_MACHINE");

                    b.Property<int>("PickedLayers")
                        .HasColumnType("int")
                        .HasColumnName("PICKED_LAYERS");

                    b.Property<long>("SeqNum")
                        .HasColumnType("bigint")
                        .HasColumnName("SEQ_NUM");

                    b.HasKey("Id");

                    b.ToTable("INGESTION");
                });
#pragma warning restore 612, 618
        }
    }
}
