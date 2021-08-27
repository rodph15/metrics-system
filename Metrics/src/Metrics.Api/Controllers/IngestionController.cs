using Metrics.Api.Interfaces;
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
        private readonly IIngestionReportService _ingestionReportService;
       
        public IngestionController(IBusClient busClient, IIngestionReportService ingestionReportService)
        {
            _busClient = busClient;
            _ingestionReportService = ingestionReportService;
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

        [HttpGet]
        public async Task<IActionResult> GetCalculation()
        {
            try
            {
                var result = await _ingestionReportService.MetricCalculation();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
