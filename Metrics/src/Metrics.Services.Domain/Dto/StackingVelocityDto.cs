using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.Services.Domain.Dto
{
    public class StackingVelocityDto
    {
        public long Velocity { get; set; }

        public override string ToString()
        {
            return $"Stacking {Velocity} per minute";
        }
    }
}
