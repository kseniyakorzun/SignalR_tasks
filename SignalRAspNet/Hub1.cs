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
            JsonReader reader = new JsonTextReader(new StringReader(json));
            var obj = Newtonsoft.Json.Linq.JObject.Load(reader);

            var type = obj["$type"]?.ToString();

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new NotSupportedException();
            }

            var subtype = type!.Split(',')[0].Split('.').ToList().Last();

            switch (subtype)
            {
                //case nameof(Human):
                //    var human = JsonConvert.DeserializeObject<User>(json);
                //    Console.WriteLine($"{DateTime.Now} Received: {human.Name} {human.Surname}");
                //    await Clients.All.SendAsync("ReceiveJson", human);
                //    break;
                case nameof(User):
                    var user = JsonConvert.DeserializeObject<User>(json);
                    Console.WriteLine($"{DateTime.Now} Received: {user.Name} {user.Surname} with role {user.Role}");
                    await Clients.All.SendAsync("ReceiveJson", user);
                    break;
                case nameof(Worker):
                    var worker = JsonConvert.DeserializeObject<Worker>(json);
                    Console.WriteLine($"{DateTime.Now} Received worker: {worker.Name} {worker.Surname} wwith occupation {worker.Occupation}");
                    await Clients.All.SendAsync("ReceiveJson", worker);
                    break;
                default: throw new NotSupportedException();
            } 
        }
    }
}
