using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SignalR
{
    public class Human
    {
        [DataMember(Name = "name")]
        [JsonProperty("name")]
        [JsonInclude]
        public string Name { get; set; }

        [DataMember(Name = "surname")]
        [JsonProperty("surname")]
        [JsonInclude]
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{DateTime.Now} {this.GetType().Name} found: {this.Name} {this.Surname}";
        }
    }

    public class Worker : Human
    {

        [DataMember(Name = "occupation")]
        [JsonProperty("occupation")]
        [JsonInclude]
        public string Occupation { get; set; }

        public override string ToString()
        {
            return $"{DateTime.Now} {this.GetType().Name} found: {this.Name} {this.Surname} with occupation {this.Occupation}";
        }
    }

    public class User : Human
    {

        [DataMember(Name = "role")]
        [JsonProperty("role")]
        [JsonInclude]
        public string Role { get; set; }

        public override string ToString()
        {
            return $"{DateTime.Now} {this.GetType().Name} found: {this.Name} {this.Surname} with role {this.Role}";
        }
    }
}
