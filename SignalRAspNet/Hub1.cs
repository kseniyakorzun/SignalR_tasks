using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SignalR;

namespace SignalRAspNet
{
    public class Hub1 : Hub
    {
        public async Task SendMessage(string message)
        {
            Console.WriteLine(message);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task SendJson(string json)
        {
            var jsonUser = JsonConvert.DeserializeObject<User>(json);
            Console.WriteLine($"{DateTime.Now} Received: {jsonUser.Name} with role {jsonUser.Role}");
            await Clients.All.SendAsync("ReceiveJson", jsonUser);
        }
    }
}
