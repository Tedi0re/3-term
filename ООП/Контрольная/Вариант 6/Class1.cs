using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Вариант_6
{
    class Bus : IComparable<Bus>
    {
        static readonly string name;//сиатическое неизменяемое
        static string color;//статическое
        public int seatBus;//экземплярное

        public static bool operator <(Bus bus1, Bus bus2)//перегрузка оператора для метода compareble
        {
            return bus1.seatBus < bus2.seatBus;
        }

        public static bool operator >(Bus bus1, Bus bus2)//перегрузка операторадля метода compareble
        {
            return bus1.seatBus > bus2.seatBus;
        }

        public static bool operator ==(Bus bus1, Bus bus2)//перегрузка операторадля метода compareble
        {
            return bus1.seatBus == bus2.seatBus;
        }

        public static bool operator !=(Bus bus1, Bus bus2)//перегрузка операторадля метода compareble
        {
            return bus1.seatBus != bus2.seatBus;
        }

        public Bus(int seat)//конструктор
        {
            seatBus = seat;
        }
        static Bus()//статический конструктор
        {
            name = "bus";
            color = "yellow";
        }

        public int CompareTo( Bus other)//сравнение 
        {
            if (this > other) return 1;
            if (this < other) return -1;
            if (this == other) return 0;
            return 0;
        }
    }

}
