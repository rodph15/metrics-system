using Metrics.CrossCutting.IoC.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Metrics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngestionController : Controller
    {
        private readonly IBusClient _busClient;
       
        public IngestionController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIngestion([FromBody] CreateIngestion command)
        {
            try
            {
                await _busClient.PublishAsync(command);

                return Accepted($"ingestion/{command.MachineId}");
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
