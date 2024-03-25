using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo;

public class User
{
    [JsonProperty("user")]
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    [JsonIgnore]
    public int Age { get; set; } = 100;
}
