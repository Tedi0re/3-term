using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Lab_12.FileSystem
{
    static class SAAFileInfo
    {
        public static string GetFileInfo(string path)
        {
            FileInfo file = new FileInfo(path);
            string info = "Имя файла: " + file.Name +
                "\nПолный путь файла: " + file.DirectoryName +
                "\nРазмер файла в байтах: " + file.Length +
                "\nРасширение: " + file.Extension +
                "\nДата создания: " + file.CreationTime +
                "\nДата последнего изменения: " + file.LastWriteTime + "\n";
            return info;
        }
    }
}
