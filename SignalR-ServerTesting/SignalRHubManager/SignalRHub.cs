using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_ServerTesting.SignalRHubManager
{
    public class SignalRHub : Hub
    {
        public async Task SendMethod(string user, string message)
        {
            if (Clients == null)
            {
                Debug.WriteLine("Client is Null");
            }
            else
            {
                try
                {
                    Debug.WriteLine("Updating all Clients");

                    await Clients.All.SendAsync("ReceiveServerMessage", user, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
