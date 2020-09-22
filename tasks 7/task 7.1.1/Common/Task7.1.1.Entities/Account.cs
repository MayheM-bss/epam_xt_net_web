using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._1._1.Entities
{
    public class Account
    {
        [JsonProperty]
        public string Login { get; private set; }
        [JsonProperty]
        public string Password { get; private set; }
        [JsonProperty]
        public string Role { get; private set; }

        [JsonConstructor]
        public Account(string login, string password, string role)
        {
            Login = login;
            Password = password;
            Role = role;
        }
    }
}
