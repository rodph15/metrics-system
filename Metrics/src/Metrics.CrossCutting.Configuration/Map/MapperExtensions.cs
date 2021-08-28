using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Configuration.Map
{
    public static class MapperExtensions
    {
        public static void AddMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
