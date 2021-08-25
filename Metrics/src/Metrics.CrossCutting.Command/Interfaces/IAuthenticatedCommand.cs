using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Command.Interfaces
{
    public interface IAuthenticatedCommand : ICommand
    {
        public Guid UserId { get; set; }
    }
}
