using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ServerTesting
{
    public class SignalRConnectionManager
    {
        public HubConnection ConnectHub()
        {
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5005/SignalRHub")
                .Build();
            connection.StartAsync();
            return connection;
        }
    }
}
