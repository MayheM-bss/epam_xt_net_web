using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;

namespace task_4._1._1
{
    static class Observer
    {
        private static FileSystemWatcher _dirWatcher;
        private static FileSystemWatcher _fileWatcher;
        public static void StartWatch(string sourceDir, string copySourceDir, string tempDir)
        {
            DirectoryInfo backupDir = Directory.CreateDirectory(ProgramPaths.LogFilePath.Replace(@"\log.txt", ""));
            backupDir.Attributes = FileAttributes.Hidden;
            File.Create(ProgramPaths.WatchedDirFile).Close();
            ProgramPaths.SetWatcheDirInFile();
            File.Open(ProgramPaths.LogFilePath, FileMode.OpenOrCreate).Close();
            Directory.CreateDirectory(tempDir);
            _dirWatcher = new FileSystemWatcher(sourceDir);
            _fileWatcher = new FileSystemWatcher(sourceDir, "*.txt");
            ConfigurateDirWatcher();
            ConfigurateFileWatcher();
            DirCopyTxt(sourceDir, copySourceDir);
            
            Console.WriteLine("Press \'q\' to quit the sample.");
            while (Console.Read() != 'q') ;

        }

        public static void DirCopyTxt(string sourceDir, string copySourceDir)
        {
            if (!Directory.Exists(copySourceDir))
            {
                Directory.CreateDirectory(copySourceDir);
            }

            DirectoryInfo sdir = new DirectoryInfo(sourceDir);

            FileInfo[] files = sdir.GetFiles("*.txt");

            DirectoryInfo[] directories = sdir.GetDirectories();

            foreach (var file in files)
            {
                File.Copy(file.FullName, file.FullName.Replace(sourceDir, copySourceDir), true);
            }

            foreach (var directory in directories)
            {
                Directory.CreateDirectory(directory.FullName.Replace(sourceDir, copySourceDir));
                DirCopyTxt(directory.FullName, directory.FullName.Replace(sourceDir, copySourceDir));
            }

        }

        private static void ConfigurateDirWatcher()
        {
            _dirWatcher.NotifyFilter = NotifyFilters.DirectoryName;
            _dirWatcher.IncludeSubdirectories = true;

            _dirWatcher.Deleted += OnDeleted;
            _dirWatcher.Created += OnChanged;
            _dirWatcher.Renamed += OnRenamed;

            _dirWatcher.EnableRaisingEvents = true;
        }

        private static void ConfigurateFileWatcher()
        {
            _fileWatcher.NotifyFilter = NotifyFilters.LastWrite
                                        | NotifyFilters.LastAccess
                                        | NotifyFilters.FileName;

            _fileWatcher.Created += OnChanged;
            _fileWatcher.Changed += OnChanged;
            _fileWatcher.Deleted += OnDeleted;
            _fileWatcher.Renamed += OnRenamed;

            _fileWatcher.IncludeSubdirectories = true;
            _fileWatcher.EnableRaisingEvents = true;
            
        }

        private static void OnChanged (object source, FileSystemEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (source == _fileWatcher)
                    {
                        string tempPath = GetTempPath(e);
                        if (!Directory.Exists(e.FullPath.Replace(ProgramPaths.WatchedDir, ProgramPaths.TempDir).Replace(Path.GetFileName(e.Name), "")))
                        {
                            Directory.CreateDirectory(e.FullPath.Replace(ProgramPaths.WatchedDir, ProgramPaths.TempDir).Replace(Path.GetFileName(e.Name), ""));
                        }

                        File.Copy(e.FullPath, tempPath);
                        Log.LogInfo(source, e);
                    }
                    else if (source == _dirWatcher)
                    {
                        Log.LogInfo(source, e);
                    }

                    return;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnRenamed (object source, RenamedEventArgs e)
        {
            while(true)
            {
                try
                {
                    if(source == _fileWatcher)
                    {
                        Log.LogInfo(source, e);
                    }
                    else if (source == _dirWatcher)
                    {
                        Log.LogInfo(source, e);
                    }

                    return;
                }
                catch
                {
                    Thread.Sleep(1);
                }
            }
        }

        private static void OnDeleted (object source, FileSystemEventArgs e)
        {
            while(true)
            {
                try
                {
                    if(source == _fileWatcher)
                    {
                        Log.LogInfo(source, e);
                    }
                    else if(source == _dirWatcher)
                    {
                        Log.LogInfo(source, e);
                    }

                    return;
                }

                catch
                {
                    Thread.Sleep(1);
                }

            }
        }

        private static string GetTempPath(FileSystemEventArgs e)
        {
            string tempPath = e.FullPath.Replace(ProgramPaths.WatchedDir, ProgramPaths.TempDir).
                            Replace(Path.GetFileName(e.Name), $"#{Log.DateFormatLog(DateTime.Now)}#{Path.GetFileName(e.Name)}");
            return tempPath;
        }
    }
}
