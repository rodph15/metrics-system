using Metrics.CrossCutting.Command.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metrics.CrossCutting.Command.Commands
{
    public class CreateUser : ICommand
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
