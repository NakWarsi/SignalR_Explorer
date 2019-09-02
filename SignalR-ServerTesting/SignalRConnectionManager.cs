using Microsoft.AspNetCore.SignalR.Client;

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
