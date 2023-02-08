using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Lab_12.FileSystem
{
    static class SAAlog
    {

        public static void WriteInfo(string path, string className, string info)
        {
            using (StreamWriter Write = new StreamWriter(path,true))
            {
                Write.WriteLine("---------------------" + className + "----------------------");
                Write.WriteLine(DateTime.Now);
                Write.WriteLine(info);
            }
        }

        public static string Read(string path)
        {
            string info;
            using (StreamReader reader = new StreamReader(path))
            {
                info = reader.ReadToEnd();
            }
            return info;
        }
    }
}
