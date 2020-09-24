using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7._1._1.Entities
{
    public class Award
    {
        [JsonProperty]
        public Guid ID { get; private set; }
        [JsonProperty]
        public string Title { get; private set; }
        [JsonProperty]
        public List<User> Users { get; private set; }

        private Award()
        {
            ID = Guid.NewGuid();
            Users = new List<User>();
        }

        public Award(string title) : this()
        {
            Title = title;
        }

        [JsonConstructor]
        public Award(Guid id, string title, List<User> users)
        {
            ID = id;
            Title = title;
            Users = users;
        }

    }
}
