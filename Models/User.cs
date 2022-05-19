using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SignalR
{
    public class User
    {
        [DataMember(Name = "name")]
        [JsonProperty("name")]
        [JsonInclude]
        public string Name { get; set; }

        [DataMember(Name = "role")]
        [JsonProperty("role")]
        [JsonInclude]
        public string Role { get; set; }

        public override string ToString()
        {
            return $"{DateTime.Now} User {this.Name} with role {this.Role}";
        }
    }
}
