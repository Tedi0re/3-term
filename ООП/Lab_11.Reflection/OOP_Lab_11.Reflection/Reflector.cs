using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace OOP_Lab_11.Reflection
{
    static class Reflector
    {
        public static string GetAssemblyName(Type Class)
        {
            string AssemblyInfo ="Имя сборки: " + Class.AssemblyQualifiedName;
            return AssemblyInfo;
        }

        public static IEnumerable<string> PublicConstuctors(Type Class)
        {
            ConstructorInfo[] PublicConstructorInfo = Class.GetConstructors();
            List<string> str = new List<string>() { Convert.ToString("Всего открытых конструкторов: " + PublicConstructorInfo.Length) };
            for (int i = 0; i < PublicConstructorInfo.Length ; i++)
            {
                str.Add(Convert.ToString(PublicConstructorInfo[i]));
            }
            return str;
        }

        public static IEnumerable<string> GetSetFieldInfo(Type Class)
        {
            FieldInfo[] fieldInfo = Class.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            PropertyInfo[] propertyInfo = Class.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            List<string> str = new List<string>();
            for (int i = 0; i < fieldInfo.Length + propertyInfo.Length; i++)
            {
                if(i < fieldInfo.Length)
                {
                    if (i == 0) str.Add("Поля класса:");
                    str.Add(Convert.ToString(fieldInfo[i]));
                }
                else
                {
                    if (i == fieldInfo.Length) str.Add("Свойства класса:");
                    str.Add(Convert.ToString(propertyInfo[i - fieldInfo.Length]));
                }
            }
            return str;
        }

        public static IEnumerable<string> InterfaceInfo(Type Class)
        {
            List<string> interfaces = new List<string>() { "Реализованные интерфейсы:" };
            foreach (var item in Class.GetInterfaces())
            {
                interfaces.Add(Convert.ToString(item));
            }
            return interfaces;
        }

        public static IEnumerable<string> AllMethods(Type Class)
        {
            MethodInfo[] methodInfos = Class.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var Paremeter = (int)2;
            Type ParameterType = Paremeter.GetType();
            List<string> Methods = new List<string>() { $"Все методы с типом параметра {ParameterType.Name}:" };
            var MethodInfos = from selected in methodInfos
                          where !selected.Name.StartsWith("get_") && !selected.Name.StartsWith("set_")
                          select selected;
            foreach (var Method in MethodInfos)
            {
                
                foreach (var parameter in Method.GetParameters())
                {
                    if(Convert.ToString(parameter.ParameterType.Name) == Convert.ToString(ParameterType.Name))
                    {
                        Methods.Add(Convert.ToString(Method));
                    }
                }
            }
            return Methods;
        }

        public static object? Invoke(object? obj, string MethodName, object[] Parameters = null)
        {
           var Method = obj.GetType().GetMethod(MethodName);
           return Method?.Invoke(obj, Parameters);
        }

        public static object? Create(Type type, object[] Parameters)
        {
            ConstructorInfo[] constructors= type.GetConstructors();
            foreach (var constructor in constructors)
            {
                try
                {
                    return constructor.Invoke(Parameters);
                }
                catch (Exception) { }
            }
            return null;
        }

    }

    

    public interface IBirthDay
    {
        int BirthDay();
    }
    class person:IBirthDay
    {
        public string Name;
        public int Age;
        private int Money;

        public int money
        {
            get => Money;
            set => Money = value;
        }

        public person()
        {

        }

        public person(string name)
        {
            Name = name;
        }

        public person(string name, int a, int m = 0)
        {
            Name = name;
            Age = a;
            Money = m;
        }

        private person(int a)
        {
            Name = "a";
        }

        public int BirthDay()
        {
            this.Age++;
            Console.WriteLine($"Исполнилось {Age} лет");
            return Age;
        }

        public int numberParameter(int a)
        {
            Console.WriteLine($"numberParameter - {a}");
            return a;
        }
    }
}
