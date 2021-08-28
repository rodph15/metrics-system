using Metrics.Api.Handlers;
using Metrics.Api.Interfaces;
using Metrics.Api.Services;
using Metrics.CrossCutting.Configuration.Mapper;
using Metrics.CrossCutting.IoC.Events;
using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.CrossCutting.IoC.RabbitMq;
using Metrics.Services.Domain.Interface;
using Metrics.Services.Infrastructure.Context;
using Metrics.Services.Infrastructure.Repositories;
using Metrics.Services.Infrastructure.UoW;
using Metrics.Services.Ingestion.Handlers;
using Metrics.Services.Ingestion.Interfaces;
using Metrics.Services.Ingestion.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMapperProfile();
            services.AddControllers();
            services.AddHealthChecks().AddDbContextCheck<MetricsDbContext>();
            services.AddDbContext<MetricsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton, ServiceLifetime.Singleton);
            services.AddScoped<IIngestionRepository, IngestionRepository>();
            services.AddScoped<IIngestionReportService, IngestionReportService>();
            services.AddScoped<IEventHandler<IngestionCreatedEvent>, IngestionCreatedHandler>();
            services.AddScoped<IIngestionRepository, IngestionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICreateIngestionService, CreateIngestionService>();
            services.AddRabbitMq(Configuration);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
