using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OOP_Lab_11.Reflection
{
    public struct Data
    {
        public string AssemblyName;
        public IEnumerable<string> PublicConstuctors;
        public IEnumerable<string> GetSetFieldInfo;
        public IEnumerable<string> InterfaceInfo;
        public IEnumerable<string> AllMethods;

        public Data(string assemblyName, IEnumerable<string> publicConstructors, IEnumerable<string> getSetFieldInfo, IEnumerable<string> interfaceInfo, IEnumerable<string> allMethods)
        {
            AssemblyName = assemblyName;
            PublicConstuctors = publicConstructors;
            GetSetFieldInfo = getSetFieldInfo;
            InterfaceInfo = interfaceInfo;
            AllMethods = allMethods;
        }

        public void Print(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                string text = "";
                Console.WriteLine(AssemblyName);
                text += AssemblyName + "\n";
                foreach (var item in PublicConstuctors)
                {
                    Console.WriteLine(item);
                    text += item + "\n";
                }
                foreach (var item in GetSetFieldInfo)
                {
                    Console.WriteLine(item);
                    text += item + "\n";
                }
                foreach (var item in InterfaceInfo)
                {
                    Console.WriteLine(item);
                    text += item + "\n";
                }
                foreach (var item in AllMethods)
                {
                    Console.WriteLine(item);
                    text += item + "\n";
                }
                writer.Write(text);
            }
            
        }
    }
}
