using Metrics.CrossCutting.IoC.Events;
using Metrics.CrossCutting.IoC.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metrics.CrossCutting.IoC.Handlers
{
    public class UserCreatedHandler : IEventHandler<UserCreatedEvent>
    {
        public async Task HandlerAsync(UserCreatedEvent @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"User task finished with id: {@event.Email}");
        }

        
    }
}
