using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OOP_Lab_9
{
    class Employee : IEnumerable
    {
        public readonly string Name;
        private List<Tool> _tools;
        private int Counter;

        public Employee(string name)
        {
            Name = name;
            _tools = new List<Tool>();
            Counter = 0;
        }

        public void AddTool(Tool tool)
        {
            if(tool != null)
            {
                if(!_tools.Contains(tool))
                {
                    _tools.Add(tool);
                    Counter++;
                }
                else
                {
                    Console.WriteLine("Такой инструмент уже есть");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Инструмент == null");
                Console.ResetColor();
            }
        }

        public void RemoveTool(Tool tool)
        {
            if (tool != null)
            {
                if (_tools.Contains(tool))
                {
                    _tools.Remove(tool);
                    Counter--;
                }
                else
                {
                    Console.WriteLine("Нет такого инструмента");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Инструмент == null");
                Console.ResetColor();
            }
        }

        public override string ToString()
        {
            string str;
            str = base.ToString();
            str += " " + this.Name;
            return str;
        }

        public override int GetHashCode()
        {
            return Counter * Counter + Name.Length - (int)Name[0];
        }

        public IEnumerator GetEnumerator() => _tools.GetEnumerator();

        public class Tool
        {
            public string Name;

            public Tool(string name)
            {
                Name = name;
            }
        }
    }
}
