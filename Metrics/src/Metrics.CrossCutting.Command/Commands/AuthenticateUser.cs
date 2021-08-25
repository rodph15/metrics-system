using Metrics.CrossCutting.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Command.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
