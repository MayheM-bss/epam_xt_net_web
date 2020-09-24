using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.DAL.Interfaces;
using Task7._1._1.Entities;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Web.Configuration;

namespace Task7._1._1.DAL
{
    public class UserDAO : IUserDAO
    {
        private static readonly string _directory = WebConfigurationManager.AppSettings.Get("pathToUserJSON");
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DateFormatString = "dd.MM.yyyy"
        };
        public UserDAO()
        {
            Directory.CreateDirectory(_directory);
        }

        public void Save(User user)
        {
            var json = JsonConvert.SerializeObject(user, Formatting.Indented, _settings);

            using (var writer = new StreamWriter(GetPath(user.ID), false))
            {
                writer.Write(json);
            }
        }

        public void DeleteById(Guid id)
        {
            File.Delete(GetPath(id));
        }

        public User GetById(Guid id)
        {
            FileInfo file = new FileInfo(GetPath(id));
            if (file.Exists)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    return JsonConvert.DeserializeObject<User>(reader.ReadToEnd(), _settings);
                }
            }
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            foreach (var file in new DirectoryInfo(_directory).GetFiles())
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    yield return JsonConvert.DeserializeObject<User>(reader.ReadToEnd(), _settings);
                }
            }
        }

        private static string GetPath(Guid id)
        {
            return _directory + "User_" + id + ".json";
        }


    }
}
