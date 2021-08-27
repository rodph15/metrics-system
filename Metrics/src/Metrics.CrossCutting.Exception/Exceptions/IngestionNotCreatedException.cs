using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.ExceptionManagement.Exceptions
{
    public class IngestionNotCreatedException : Exception
    {
        public IngestionNotCreatedException() : base("Something went wrong ingestion creation")
        {
        }
    }
}
