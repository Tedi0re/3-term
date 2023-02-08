using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Lab_12.FileSystem
{
    static class SAADiskInfo
    {
        public static string GetDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            string info = "";
            foreach (DriveInfo drive in drives)
            {
                info += "Название: " + drive.Name + "\n" +
                    "Тип: " + drive.DriveType + "\n";
                if (drive.IsReady)
                {
                    info += "Объем диска: " + drive.TotalSize +
                        "\nСвободное пространство: " + drive.TotalFreeSpace +
                        "\nФайловая система: " + drive.DriveFormat +
                        "\nМетка диска: " + drive.VolumeLabel + "\n";
                }
            }
            return info;
        }
    }
}
