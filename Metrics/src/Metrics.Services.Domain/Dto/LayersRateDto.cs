using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Services.Domain.Dto
{
    public class LayersRateDto
    {
        public long Rate { get; set; }

        public override string ToString()
        {
            return $"Rate {Rate} per minute";
        }
    }
}
