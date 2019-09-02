using Microsoft.AspNetCore.SignalR.Client;

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
