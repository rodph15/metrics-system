using FluentAssertions;
using Metrics.Services.Domain.Entities;
using Metrics.Services.Domain.Interface;
using Metrics.Services.Ingestion.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Metrics.Services.Ingestion.Tests.Unit.Services
{
    public class CreateIngestionServiceTests
    {
        [Fact]
        public async Task Add_object_should_save_not_throw_exception()
        {
            var ingestionRepositoryMock = new Mock<IIngestionRepository>();
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            var ingestionService = new CreateIngestionService(ingestionRepositoryMock.Object, unitOfWorkMock.Object);

            unitOfWorkMock.Setup(x => x.CommitAsync()).ReturnsAsync(true);

            var result = await ingestionService.Add(new IngestionEntity());

            result.Should().BeTrue();

        }
    }
}
