using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4._1._1
{
    class ChangesInfo
    {
        public DateTime ChangeTime { get; private set; }
        public string ChangeType { get; private set; }
        public string Path { get; private set; }
        public string OldPath { get; private set; }

        public ChangesInfo(string time, string changeType, string path)
        {
            ChangeTime = DateTime.Parse(time);
            ChangeType = changeType;
            Path = path;
        }

        public ChangesInfo(string time, string changeType, string path, string oldPath)
            : this (time, changeType, path)
        {
            OldPath = oldPath;
        }

        public static List<ChangesInfo> ListLogInfo(DateTime date)
        {
            List<ChangesInfo> items = new List<ChangesInfo> { };
            using (StreamReader reader = File.OpenText(ProgramPaths.LogFilePath))
            {
                string logLine;
                while((logLine = reader.ReadLine()) != null)
                {
                    var item = LogInfo(logLine);
                    if(item.ChangeTime < date)
                    {
                        items.Add(item);
                    }

                }
            }
            return items;
        }

        private static ChangesInfo LogInfo(string logLine)
        {
            string[] str = logLine.Split('$');
            string changeTime = str[0];
            string changeType = str[1];

            if (changeType == "Created" || changeType == "Deleted" || changeType == "Changed")
            {
                string path = str[2];
                return new ChangesInfo(changeTime, changeType, path);
            }
            else
            {
                string oldPath = str[3];
                string path = str[2];
                return new ChangesInfo(changeTime, changeType, path, oldPath);
            }
        }

    }
}
