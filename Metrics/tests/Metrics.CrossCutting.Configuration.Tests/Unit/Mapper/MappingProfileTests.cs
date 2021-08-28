using AutoMapper;
using Metrics.CrossCutting.Configuration.Map;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Metrics.CrossCutting.Configuration.Tests.Unit.Map
{
    public class MappingProfileTests
    {
        [Fact]
        public void MappingProfile_VerifyValidConfiguration()
        {
            var mappingProfile = new MappingProfile();

            var config = new MapperConfiguration(mappingProfile);
            var mapper = new Mapper(config);

            (mapper as IMapper).ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
