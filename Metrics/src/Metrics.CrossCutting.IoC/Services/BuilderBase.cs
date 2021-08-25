using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.IoC.Services
{
    public abstract class BuilderBase
    {
        public abstract ServiceHost Build();
    }
}
