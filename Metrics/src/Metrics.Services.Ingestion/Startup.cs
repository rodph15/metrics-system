using Metrics.CrossCutting.IoC.Interfaces;
using Metrics.CrossCutting.IoC.Commands;
using Metrics.CrossCutting.IoC.RabbitMq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Metrics.Services.Domain.Interface;
using Metrics.Services.Infrastructure.Repositories;
using Metrics.Services.Ingestion.Interfaces;
using Metrics.Services.Ingestion.Services;
using Metrics.Services.Ingestion.Handlers;
using Metrics.CrossCutting.Configuration.Mapper;
using Metrics.Services.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Metrics.Services.Infrastructure.UoW;
using RawRabbit;

namespace Metrics.Services.Ingestion
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
            services.AddDbContext<MetricsDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")),ServiceLifetime.Singleton, ServiceLifetime.Singleton);
            services.AddScoped<ICommandHandler<CreateIngestion>, CreateIngestionHandler>();
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
            });
        }
    }
}
