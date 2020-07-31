using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_4._1._1
{
    static class BackUpSystem
    {
        public static void StartRecovery (DateTime dateTime, string sourceDir, string sourceDirCopy)
        {
            DeleteTxtFiles(sourceDir);
            CopyBackUpFiles(sourceDirCopy);
            List<ChangesInfo> changesInfos = ChangesInfo.ListLogInfo(dateTime);

            foreach (var item in changesInfos)
            {
                switch (item.ChangeType)
                {
                    case "Changed":
                        if(!Directory.Exists(Path.GetDirectoryName(item.Path)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(item.Path));
                        }
                        if(File.Exists(item.Path))
                        {
                            File.Delete(item.Path);
                        }
                        string tempFile = GetTempFile(item);
                        File.Copy(tempFile, item.Path);
                        break;
                    case "Created":
                        if(item.Path.EndsWith(".txt"))
                        {
                            File.Create(item.Path);
                            break;
                        }
                        else
                        {
                            Directory.CreateDirectory(item.Path);
                            break;
                        }
                    case "Deleted":
                        if(item.Path.EndsWith(".txt"))
                        {
                            if (File.Exists(item.Path))
                            {
                                File.Delete(item.Path);
                            }
                            break;
                        }
                        else
                        {
                            if (Directory.Exists(item.Path))
                            {
                                Directory.Delete(item.Path, true);
                            }
                            break;
                        }
                    case "Renamed":
                        if(item.Path.EndsWith(".txt"))
                        {
                            if (File.Exists(item.OldPath))
                            {
                                File.Delete(item.OldPath);
                            }
                            File.Create(item.Path).Close();
                            
                            break;
                        }
                        else
                        {
                            if (Directory.Exists(item.OldPath))
                            {
                                Directory.Delete(item.OldPath);
                            }
                            Directory.CreateDirectory(item.Path);
                            
                            break;
                               
                        }
                        
                    
                }
            }
        }

        private static void DeleteTxtFiles(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*.txt", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                file.Delete();
            }
        }

        private static void CopyBackUpFiles (string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*.txt", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                if(!Directory.Exists(file.DirectoryName))
                {
                    Directory.CreateDirectory(file.DirectoryName);
                }
                File.Copy(file.FullName, file.FullName.Replace(ProgramPaths.WatchedDirCopy, ProgramPaths.WatchedDir), true);
            }
        }

        private static string GetTempFile(ChangesInfo info)
        {
            string path = info.Path.Replace(ProgramPaths.WatchedDir, ProgramPaths.TempDir).Replace(Path.GetFileName(info.Path), "");
            path = Path.Combine(path, $"#{Log.DateFormatLog(info.ChangeTime)}#{Path.GetFileName(info.Path)}");
            return path;

        }
    }
}
