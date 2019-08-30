using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_ServerTesting.SignalRHubManager
{
    public class SignalRHub : Hub
    {
        public async Task SendMethod(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveServerMessage", user, message);
            Dispose();
        }
    }
}
