using FluentAssertions;
using Metrics.Api.Controllers;
using Metrics.Api.Interfaces;
using Metrics.CrossCutting.IoC.Commands;
using Metrics.Services.Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Metrics.Api.Tests.Unit.Controllers
{
    public class IngestionControllerTests
    {
        private Mock<IBusClient> _busClientMock;
        private Mock<IIngestionReportService> _ingestionServiceMock;

        public IngestionControllerTests()
        {
            _busClientMock = new Mock<IBusClient>();
            _ingestionServiceMock = new Mock<IIngestionReportService>();
        }

        [Fact]
        public async Task CreateIngestion_post_should_return_accepted()
        {
            var controller = new IngestionController(_busClientMock.Object, _ingestionServiceMock.Object);

            var result = await controller.CreateIngestion(new CreateIngestion { MachineId = 1 });

            var contentResult = result as AcceptedResult;
            contentResult.Should().NotBeNull();
            contentResult.Location.Should().BeEquivalentTo($"ingestion/{1}");

        }

        [Fact]
        public async Task StackingVelocity_get_should_return_string()
        {
            _ingestionServiceMock.Setup(x => x.StackingVelocity()).ReturnsAsync(new StackingVelocityDto { Velocity = 5 });
            var controller = new IngestionController(_busClientMock.Object, _ingestionServiceMock.Object);

            var result = await controller.StackingVelocity();

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult.Value.Should().BeEquivalentTo($"Stacking {5} per minute");

        }

        [Fact]
        public async Task LayersRate_get_should_return_string()
        {
            _ingestionServiceMock.Setup(x => x.LayersRate()).ReturnsAsync(new LayersRateDto { Rate = 5 });
            var controller = new IngestionController(_busClientMock.Object, _ingestionServiceMock.Object);

            var result = await controller.LayersRate();

            var contentResult = result as OkObjectResult;
            contentResult.Should().NotBeNull();
            contentResult.Value.Should().BeEquivalentTo($"Rate {5} per minute");

        }
    }
}
