using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR.Client;
using SignalR_ChatClient.Hubs;

namespace SignalR_ChatClient
{
    public class Client
    {
        public static HubConnection connection;
        public ChatHub chathub= new ChatHub();
        public static void Main(string[] args)
        {
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:7000/SignalRHub")
                .Build();
            var task = connection.StartAsync();
            task.GetAwaiter().GetResult();
            //connection.Closed += async (error) =>
            //{
            //    await Task.Delay(new Random().Next(0,5) * 1000);
            //    await connection.StartAsync();
            //};

            connection.On<string, string>("ReceiveServerMessage", (user, message) =>
            {
                Console.WriteLine(user);
                Console.WriteLine(message);
            });

            CreateWebHostBuilder(args).Build().Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
