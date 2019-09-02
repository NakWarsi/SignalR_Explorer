using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR_ServerTesting.SignalRHubManager
{
    public class SignalRHub : Hub
    {
        private static int _countConnections = 0;
        public async Task SendMethod(string user, string message)
        {
            if (Clients == null)
            {
                Debug.WriteLine("\n Client is Null");
            }
            else
            {
                try
                {
                    Debug.WriteLine("\n Updating all Clients");

                    await Clients.All.SendAsync("\n ReceiveServerMessage", user, message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public void PrintConnectionInformation(int count)
        {
            Debug.WriteLine("\n number of connection established right now is: "+ count);
        }

        public override Task OnConnectedAsync()
        {
            ++_countConnections;
            Debug.WriteLine("\n connection established ");
            PrintConnectionInformation(_countConnections);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            --_countConnections;
            Debug.WriteLine("\n connection removed");
            PrintConnectionInformation(_countConnections);

            return base.OnDisconnectedAsync(exception);
        }
    }

}
