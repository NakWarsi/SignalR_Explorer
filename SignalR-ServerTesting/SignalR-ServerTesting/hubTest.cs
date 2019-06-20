using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR_ServerTesting
{
    public class HubTest
    {
        HubConnection connection;
        public HubTest()
        {
            connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:44329/ChatHub")
                .Build();
             connection.StartAsync();
        }

        public async void  SendMethod(string msg)
        {
            await connection.InvokeAsync("SendMessage",
                "abc", msg);
        }

    }
}
