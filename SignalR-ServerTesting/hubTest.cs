using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalR_ServerTesting
{
    public class HubTest
    {
        public readonly SignalRConnectionManager _signalRConnectionManager = new SignalRConnectionManager();
        public async void SendMethod(string msg)
        {
            var connection = _signalRConnectionManager.ConnectHub();
            await connection.InvokeAsync("SendMessage",
                "abc", msg);
            await connection.StopAsync();
        }
    }
}
