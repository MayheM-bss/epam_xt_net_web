using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task7._1._1.Entities
{
    public class User
    {
        [JsonProperty]
        public Guid ID { get; private set; }
        [JsonProperty]
        public string Name { get; private set; }
        [JsonProperty]
        public DateTime BirthDay { get; private set; }
        [JsonProperty]
        public int Age { get; private set; }
        [JsonProperty]
        public List<Award> Awards { get; private set; }

        private User()
        {
            ID = Guid.NewGuid();
            Awards = new List<Award>();
        }

        public User(string name, DateTime date, int age) : this()
        {
            Name = name;
            BirthDay = date;
            Age = age;
        }

        [JsonConstructor]
        public User(Guid id, string name, DateTime date, int age, List<Award> awards)
        {
            ID = id;
            Name = name;
            BirthDay = date;
            Age = age;
            Awards = awards;
        }
    }
}
