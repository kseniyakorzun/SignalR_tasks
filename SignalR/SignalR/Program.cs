using System;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SignalR;

namespace SignalRSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7182/hub1")
                    .AddJsonProtocol(options =>
                    {
                        options.PayloadSerializerOptions.PropertyNamingPolicy = null;
                    })
                    .Build();

                //StringMessageToHub(connection);
                JsonToHub(connection);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e.Message);
            }
        }

        static void StringMessageToHub(HubConnection? connection)
        {
            connection.On<string>("ReceiveMessage", Console.WriteLine);

            connection.StartAsync().Wait();
            while (true)
            {
                Thread.Sleep(2000);
                connection.InvokeAsync("SendMessage", $"{DateTime.Now} some message");
            }

        }

        static void JsonToHub(HubConnection? connection)
        {
            User user = new User { Name = "Kseniya", Role = "Developer" };
            string json = JsonConvert.SerializeObject(user);

            connection.On<User>("ReceiveJson", Console.WriteLine);

            connection.StartAsync().Wait();
            while (true)
            {
                Thread.Sleep(4000);
                connection.InvokeAsync("SendJson", json);
            }
        }
    }
}