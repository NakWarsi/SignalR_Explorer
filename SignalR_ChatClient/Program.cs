using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR_ChatClient.Hubs;

namespace SignalR_ChatClient
{
    public class Program
    {
        public static HubConnection connection;
        public static HubConnection selfHubConnection;
        private static IHubContext<ChatHub> chathub;
        public static void Main(string[] args)
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:7000/SignalRHub")
                .Build();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
            connection.On<string, string>("ReceiveServerMessage", Handler);
            connection.StartAsync().GetAwaiter();


            selfHubConnection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/chatHub")
                .Build();
            selfHubConnection.StartAsync().GetAwaiter();

            CreateWebHostBuilder(args).Build().Run();

        }


        private static void Handler(string user, string message)
        {
            Debug.WriteLine("\n\nmessage Received\n\n");
            Debug.WriteLine(user);
            Debug.WriteLine(message);

            selfHubConnection.InvokeAsync("SendMessage",
                user, message);


            //chathub.Clients.All.SendAsync("ReceiveMessage", user, message);                           // it should work but not working don't know why
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
