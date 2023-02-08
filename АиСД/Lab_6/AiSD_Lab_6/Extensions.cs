using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AiSD_Lab_6
{
    public static class Extensions
    {
        public static string Reverse(this string str)
        {
            return new string(str.ToCharArray().Reverse().ToArray());
        }
    }
}
