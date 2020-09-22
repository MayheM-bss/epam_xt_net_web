using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using Task7._1._1.DAL.Interfaces;
using Task7._1._1.Entities;

namespace Task7._1._1.DAL
{
    public class AccountDAO : IAccountDAO
    {
        private static readonly string _directory = WebConfigurationManager.AppSettings.Get("pathToAccountJSON");
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            DateFormatString = "dd.MM.yyyy"
        };

        public AccountDAO()
        {
            Directory.CreateDirectory(_directory);
            
        }
        public Account GetByLogin(string login)
        {
            FileInfo file = new FileInfo(GetPath(login));
            if (file.Exists)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    return JsonConvert.DeserializeObject<Account>(reader.ReadToEnd(), _settings);
                }
            }
            return null;
        }

        public void Save(Account account)
        {
            var json = JsonConvert.SerializeObject(account, Formatting.Indented, _settings);

            using (var writer = new StreamWriter(GetPath(account.Login), false))
            {
                writer.Write(json);
            }
        }

        private static string GetPath(string login)
        {
            return _directory + "Account_" + login + ".json";
        }
    }
}
