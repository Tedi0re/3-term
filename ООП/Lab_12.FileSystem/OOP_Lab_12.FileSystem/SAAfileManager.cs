using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.IO.Compression;

namespace OOP_Lab_12.FileSystem
{
    static class SAAfileManager
    {
        public static string ReadFiles(string drive, string path)
        {
            DriveInfo[] drive1 = DriveInfo.GetDrives();
            string info = "";
            for (int i = 0; i < drive1.Length; i++)
            {
                if(drive1[i].Name == drive)
                {
                    string[] filesAndDirectoies = Directory.GetFileSystemEntries(drive1[i].Name);
                    for (int j = 0; j < filesAndDirectoies.Length; j++)
                    {
                        info += filesAndDirectoies[j] + "\n";
                    }
                    break;
                }
            }

            Directory.CreateDirectory(Path.Combine(path, "SAAInspect"));
            using (StreamWriter file = new StreamWriter(Path.Combine(path , "SAAInspect/SAAdirinfo.txt"), true))
            {
                file.WriteLine(info);   
            }
            if (File.Exists(Path.Combine(path, "SAAInspect/SAAdirinfo1.txt")))
            {
                File.Delete(Path.Combine(path, "SAAInspect/SAAdirinfo1.txt"));
            }
            FileInfo newfile = new FileInfo(Path.Combine(path, "SAAInspect/SAAdirinfo.txt"));
            newfile.CopyTo(Path.Combine(path, "SAAInspect/SAAdirinfo1.txt"));
            File.Delete(Path.Combine(path, "SAAInspect/SAAdirinfo.txt"));

            return info;

        }

        public static string NewDirectory(string pathIn, string pathOut, string Extensions)
        {
            string info = "";
            Directory.CreateDirectory(Path.Combine(pathOut, "SAAFiles"));
            string[] AllFiles = Directory.GetFileSystemEntries(pathIn);

            var files = from f in AllFiles
                             where f.EndsWith(Extensions)
                             select f;
            foreach (var file in files)
            {
                FileInfo copyfile = new FileInfo(Path.Combine(file));
                info += copyfile.Name + "\n";
                copyfile.CopyTo(Path.Combine(pathOut, "SAAFiles", copyfile.Name), true);
            }

            return info;
        }

        public static string CompressDirectory(string pathIn, string pathOut)
        {
            string info = "";
            string namezip = "arx.zip";
            info+= pathIn + ">" + namezip + ">" + pathOut + "\n"; 
            if(File.Exists(Path.Combine(@"../../../../dir", namezip)))
            {
                File.Delete(Path.Combine(@"../../../../dir", namezip));
            }
            if(Directory.Exists(pathOut))
            {
                Directory.Delete(pathOut, true);
            }
            ZipFile.CreateFromDirectory(pathIn, Path.Combine(@"../../../../dir", namezip));
            ZipFile.ExtractToDirectory(Path.Combine(@"../../../../dir", namezip), pathOut);
            return info;
        }
    }
}
