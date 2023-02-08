using System;
using System.IO;

namespace OOP_Lab_12.FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            string pathdir = @"../../../../dir";
            string logFileName = "log.txt";
            FileInfo log = new FileInfo(Path.Combine(pathdir, logFileName));
            if (log.Exists)
            {
                log.Delete();
            }
            if (!Directory.Exists(pathdir))
            {
                Directory.CreateDirectory(pathdir);
            }

            string str1 = SAADiskInfo.GetDrives();
            Console.WriteLine(str1);
            SAAlog.WriteInfo(Path.Combine(pathdir, logFileName), "SAADiskInfo", str1);

            string str2 = SAAFileInfo.GetFileInfo(Path.Combine(pathdir, logFileName));
            Console.WriteLine(str2);
            SAAlog.WriteInfo(Path.Combine(pathdir, logFileName), "SAAFileInfo", str2);

            string str3 = SAADirectoryInfo.GetDirectiryInfo(pathdir);
            Console.WriteLine(str3);
            SAAlog.WriteInfo(Path.Combine(pathdir, logFileName), "SAADirectoryInfo", str3);

            string str4 = SAAfileManager.ReadFiles("D:\\", pathdir);
            Console.WriteLine(str4);
            SAAlog.WriteInfo(Path.Combine(pathdir, logFileName), "SAAFileManager_1", str4);

            string str5 = SAAfileManager.NewDirectory(pathdir, Path.Combine(pathdir, "SAAInspect"), ".txt");
            Console.WriteLine(str5);
            SAAlog.WriteInfo(Path.Combine(pathdir, logFileName), "SAAFileManager_2", str5);

            string str6 = SAAfileManager.CompressDirectory(Path.Combine(pathdir, "SAAInspect", "SAAFiles"), Path.Combine(pathdir,"newdirectory"));
            Console.WriteLine(str6);
            SAAlog.WriteInfo(Path.Combine(pathdir, logFileName), "SAAFileManager_2", str6);
        }
    }
}
