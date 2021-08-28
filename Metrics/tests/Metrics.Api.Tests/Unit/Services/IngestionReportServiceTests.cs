using AutoMapper;
using FluentAssertions;
using Metrics.Api.Controllers;
using Metrics.Api.Interfaces;
using Metrics.Api.Services;
using Metrics.CrossCutting.Configuration.Map;
using Metrics.CrossCutting.IoC.Commands;
using Metrics.Services.Domain.Dto;
using Metrics.Services.Domain.Entities;
using Metrics.Services.Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Metrics.Api.Tests.Unit.Controllers
{
    public class IngestionReportServiceTests
    {
        private IMapper _mapper;
        private Mock<IIngestionRepository> _ingestionRepositoryMock;
        private Mock<IIngestionReportService> _ingestionServiceMock;

        public IngestionReportServiceTests()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            _mapper = new Mapper(config);
            _ingestionRepositoryMock = new Mock<IIngestionRepository>();
            _ingestionServiceMock = new Mock<IIngestionReportService>();
        }

        [Fact]
        public async Task LayersRate_object_should_return_right_calculation()
        {
            var reportService = new IngestionReportService(_mapper, _ingestionRepositoryMock.Object);

            _ingestionServiceMock.Setup(x => x.StackingVelocity()).ReturnsAsync(new StackingVelocityDto { Velocity = 10 });
            _ingestionRepositoryMock.Setup(x => x.FirstItem(It.IsAny<Expression<Func<IngestionEntity, long>>>())).ReturnsAsync(new IngestionEntity { EndDate = 1630142822 });
            _ingestionRepositoryMock.Setup(x => x.LastItem(It.IsAny<Expression<Func<IngestionEntity, long>>>())).ReturnsAsync(new IngestionEntity { EndDate = 1630143464 });
            _ingestionRepositoryMock.Setup(x => x.SumItem(It.IsAny<Expression<Func<IngestionEntity, int>>>())).ReturnsAsync(7744);

            var result = await reportService.LayersRate();

            result.Should().NotBeNull();
            result.Should().BeOfType<LayersRateDto>();
            result.Should().Equals(10);

        }

        [Fact]
        public async Task StackingVelocity_object_should_return_right_calculation()
        {
            var reportService = new IngestionReportService(_mapper, _ingestionRepositoryMock.Object);

            _ingestionRepositoryMock.Setup(x => x.FirstItem(It.IsAny<Expression<Func<IngestionEntity, long>>>())).ReturnsAsync(new IngestionEntity { EndDate = 1630142822 });
            _ingestionRepositoryMock.Setup(x => x.LastItem(It.IsAny<Expression<Func<IngestionEntity, long>>>())).ReturnsAsync(new IngestionEntity { EndDate = 1630143464 });
            _ingestionRepositoryMock.Setup(x => x.SumItem(It.IsAny<Expression<Func<IngestionEntity, int>>>())).ReturnsAsync(7744);

            var result = await reportService.StackingVelocity();

            result.Should().NotBeNull();
            result.Should().BeOfType<StackingVelocityDto>();
            result.Should().Equals(10);

        }

    }
}
