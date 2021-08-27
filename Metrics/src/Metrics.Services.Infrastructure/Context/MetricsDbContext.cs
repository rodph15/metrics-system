using Metrics.Services.Domain.Entities;
using Metrics.Services.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Services.Infrastructure.Context
{
    public class MetricsDbContext : DbContext
    {
        public MetricsDbContext()
        {
        }

        public MetricsDbContext(DbContextOptions<MetricsDbContext> options) : base(options)
        {
            
        }

        public DbSet<IngestionEntity> IngestionEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new IngestionConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
