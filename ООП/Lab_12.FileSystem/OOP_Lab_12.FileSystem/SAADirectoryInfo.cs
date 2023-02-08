using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Lab_12.FileSystem
{
    static class SAADirectoryInfo
    {
        public static string GetDirectiryInfo(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            string info = "Полный путь: " + dir.FullName +
                "\nИмя каталога: " + dir.Name +
                "\nВремя создания: " + dir.CreationTime + 
                "\nСписок файлов: ";
            FileInfo[] files = dir.GetFiles();
            foreach (var file in files)
            {
                info += file.Name + ", ";
            }
            info += "\nСписок поддиректориев: ";
            DirectoryInfo[] dirs = dir.GetDirectories();
            foreach (var directory in dirs)
            {
                info += directory.Name + ", ";
            }
            info += "\nРодительский директорий: " + dir.Parent.Name;
            return info;
        }
    }
}
