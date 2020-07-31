using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace task_4._1._1
{
    static class Log
    {
        public static string DateFormatLog (DateTime dateTime)
        {
            string format = $"{dateTime.Day}-{dateTime.Month}-{dateTime.Year}-{dateTime.Hour}-{dateTime.Minute}-{dateTime.Second}";
            return format;
        }

        public static void LogInfo (object source, FileSystemEventArgs e)
        {
            string str = $"{DateTime.Now}${e.FullPath}${e.ChangeType}";
            if (!HasString(str))
            {
                using (StreamWriter writer = File.AppendText(ProgramPaths.LogFilePath))
                {
                    writer.WriteLine(str);
                }
            }
        }

        public static void LogInfo (object source, RenamedEventArgs e)
        {
            string str = $"{DateTime.Now}${e.OldFullPath}${e.FullPath}${e.ChangeType}";
            if (!HasString(str))
            {
                using (StreamWriter writer = File.AppendText(ProgramPaths.LogFilePath))
                {

                    writer.WriteLine(str);
                }
            }
        }

        private static bool HasString (string str)
        {
            using (StreamReader reader = File.OpenText(ProgramPaths.LogFilePath))
            {
                return reader.ReadToEnd().Contains(str);
            }
        }

    }
}
