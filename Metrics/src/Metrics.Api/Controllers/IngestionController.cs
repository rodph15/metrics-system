using Metrics.Api.Interfaces;
using Metrics.CrossCutting.IoC.Commands;
using Metrics.Services.Domain.Interface;
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
        private readonly IIngestionRepository _ingestionRepository;


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

        [HttpGet("velocity")]
        public async Task<IActionResult> StackingVelocity()
        {
            try
            {
                var result = await _ingestionReportService.StackingVelocity();
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("rate")]
        public async Task<IActionResult> LayersRate()
        {
            try
            {
                var result = await _ingestionReportService.LayersRate();
                return Ok(result.ToString());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
