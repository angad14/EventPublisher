using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventHubRestApi.Interfaces
{
    public interface IEventHub
    {
        Task<string> SendMessage(string message);
    }
}
