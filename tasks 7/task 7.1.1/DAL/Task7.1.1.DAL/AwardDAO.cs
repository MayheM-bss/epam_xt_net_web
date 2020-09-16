using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7._1._1.DAL.Interfaces;
using Task7._1._1.Entities;
using Newtonsoft.Json;
using System.Security.Policy;
using System.IO;

namespace Task7._1._1.DAL
{
    public class AwardDAO : IAwardDAO
    {
        private static readonly string _directory = Environment.CurrentDirectory + @"\Data\Awards\";
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            DateFormatString = "dd.MM.yyyy"
        };

        public AwardDAO()
        {
            Directory.CreateDirectory(_directory);
        }

        public void Save(Award award)
        {

            var json = JsonConvert.SerializeObject(award, Formatting.Indented, _settings);

            using (var writer = new StreamWriter(GetPath(award.ID), false))
            {
                writer.Write(json);
            }
        }

        public void DeleteById(Guid id)
        {
            File.Delete(GetPath(id));
        }

        public IEnumerable<Award> GetAll()
        {
            foreach (var file in new DirectoryInfo(_directory).GetFiles())
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    yield return JsonConvert.DeserializeObject<Award>(reader.ReadToEnd(),_settings);
                }
            }
        }

        public Award GetById(Guid id)
        {
            FileInfo file = new FileInfo(GetPath(id));
            if (file.Exists)
            {
                using (var reader = new StreamReader(file.FullName))
                {
                    return JsonConvert.DeserializeObject<Award>(reader.ReadToEnd(), _settings);
                }
            }
            return null;
        }

        private static string GetPath(Guid id)
        {
            return _directory + "Award_" + id + ".json";
        }
    }

}

