using Metrics.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Services.Infrastructure.Configuration
{
    public class IngestionConfiguration : IEntityTypeConfiguration<IngestionEntity>
    {
        public void Configure(EntityTypeBuilder<IngestionEntity> modelBuilder)
        {
            modelBuilder.ToTable("INGESTION");

            modelBuilder
                .Property(p => p.Id)
                .HasColumnName("ID");

            modelBuilder
                .Property(p => p.EndDate)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("END_DATE");

            modelBuilder
                .Property(p => p.InitDate)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("INIT_DATE");

            modelBuilder
                .Property(p => p.MachineId)
                .IsRequired()
                .HasColumnName("ID_MACHINE");

            modelBuilder
                .Property(p => p.PickedLayers)
                .IsRequired()
                .HasColumnName("PICKED_LAYERS");

            modelBuilder
                .Property(p => p.SeqNum)
                .IsRequired()
                .HasColumnName("SEQ_NUM");

            modelBuilder
                .Property(p => p.UserId)
                .IsRequired()
                .HasColumnName("ID_USER");

        }
    }
}
