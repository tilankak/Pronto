using System;
using System.IO;
using System.Reflection;
using Microsoft.Win32;

namespace Pronto.Utility
{
    public class ProjectPaths
    {
        private static string appName = "CFTDesktopApp";
        const string DB_PATH_NAME = "CFTDatabasePath";
        public ProjectPaths(string Name)
        {


        }


        public static string PdfViewerPath
        {
            get
            {

                //string curPath = InstallerRegistryPath;
                //string mainDir = Directory.GetParent(Path.GetDirectoryName(curPath.Replace("|vstolocal", ""))).FullName;
                string pdfViewer = InstallerRegistryPath; ;
                return pdfViewer;
            }
        }


        public static string InstallerRegistryPath
        {
            get
            {
                string key = @"SOFTWARE\CFT";
                string Name = "PdfViewerPath";

                string readedPath = ReadRegistry(key, Name, RegistryView.Registry64);

                if (string.IsNullOrEmpty(readedPath))
                {
                    readedPath = ReadRegistry(key, Name, RegistryView.Registry32);
                }

                return readedPath;

            }
        }


        private static string ReadRegistry(string key, string Name, RegistryView ViewType)
        {
            using (var basekey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, ViewType))
            {
                if (basekey != null)
                {
                    using (RegistryKey k = basekey.OpenSubKey(key))
                    {

                        if (k != null)
                        {
                            string Value = k.GetValue(Name).ToString();
                            return Value;
                        }
                    }
                }
            }

            return null;

        }
        public static string InstallerLogPath
        {
            get
            {
                string LogDirectory = Path.Combine(ClientPath, "CFT");
                if (!Directory.Exists(LogDirectory))
                { Directory.CreateDirectory(LogDirectory); }
                return LogDirectory;
            }
        }


        public static string InstallationPath
        {
            get
            {
                string installFile = Assembly.GetExecutingAssembly().Location;
                return Path.GetDirectoryName(installFile);
            }
        }
        public static string DatabasePath
        {
            get
            {
                string DBpath = Environment.GetEnvironmentVariable(DB_PATH_NAME, EnvironmentVariableTarget.Machine);

                if (string.IsNullOrEmpty(DBpath))
                {
                    string dbDirectory = Path.Combine(ClientPath, "CFT", "Data");
                    if (!Directory.Exists(dbDirectory))
                    { Directory.CreateDirectory(dbDirectory); }

                    DBpath = Path.Combine(ClientPath, "CFT", "Data", "FolderPermisions.sqlite");
                    Environment.SetEnvironmentVariable(DB_PATH_NAME, DBpath, EnvironmentVariableTarget.Machine);
                }

                return DBpath;
            }
        }
        public static string Licensepath
        {
            get
            {
                string licFile = "GroupDocs.Total.Product.Family.lic";
                string licPath = Path.GetDirectoryName(DatabasePath);
                licPath = Path.Combine(licPath, licFile);

                if (!File.Exists(licPath))
                {
                    string licOriginal = Path.Combine(Pronto.Utility.ProjectPaths.InstallationPath, licFile);
                    File.Copy(licOriginal, licPath);
                }

                return licPath;
            }
        }

        public static void DeleteDBpath()
        {
            Environment.SetEnvironmentVariable(DB_PATH_NAME, null);
            // Confirm the deletion.
            if (Environment.GetEnvironmentVariable(DB_PATH_NAME) == null) ;


        }

        private static string ClientPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            }
        }
        public static string AppDataPath
        {
            get
            {
                string strPath = "";
                if (String.IsNullOrEmpty(strPath) == true)
                {
                    strPath = ClientPath;
                    strPath = System.IO.Path.Combine(strPath, AppName);//addonName
                }
                if (System.IO.Directory.Exists(strPath) == false)
                { System.IO.Directory.CreateDirectory(strPath); }
                return strPath;
            }
        }

        public static string TempFilePath
        {
            get
            {
                var tempPath = Path.Combine(AppDataPath, "TempFiles");
                if (!Directory.Exists(tempPath))
                    Directory.CreateDirectory(tempPath);
                return tempPath;
            }
        }
        public static string TempFilePath1
        {
            get
            {
                var tempPath = Path.Combine(AppDataPath, "TempFiles1");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                return tempPath;
            }
        }

        public static string TempPDFPath
        {
            get
            {
                var tempPath = Path.Combine(AppDataPath, "TempPDFPath");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                return tempPath;
            }
        }

        public static string TempPDFPath1
        {
            get
            {
                var tempPath = Path.Combine(AppDataPath, "TempPDFPath1");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                return tempPath;
            }
        }


        public static string TempCFTXPath
        {
            get
            {
                var tempPath = Path.Combine(AppDataPath, "CFTX");
                if (!Directory.Exists(tempPath))
                {
                    Directory.CreateDirectory(tempPath);
                }
                return tempPath;
            }
        }

        public static string AppName
        {
            get
            {
                return appName;//addonName
            }
            set
            {
                appName = value;
            }
        }
    }
}
