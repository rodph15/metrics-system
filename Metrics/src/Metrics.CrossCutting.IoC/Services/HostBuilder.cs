using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Services
{
    public class HostBuilder : BuilderBase
    {
        private readonly IWebHost _webHost;
        private IBusClient _busClient;

        public BusBuilder UseRabbitMq()
        {
            _busClient = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));

            return new BusBuilder(_webHost, _busClient);
        }

        public HostBuilder(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}
