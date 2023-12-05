using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_OOP
{
    public class Str
    {
        public static string RemoveElement(string str)
        {
            char[] element = { '.', ',', '!', '?', '-', ':' };
            for (var i = 0; i < str.Length; i++)
            {
                if (element.Contains(str[i]))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        
        public static string RemoveSpaсe(string str)
        {
            return str.Replace(" ", string.Empty);
        }
        
        public static string Upper(string str)
        {
            for (var i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToUpper(str[i]));
            }
            return str;
        }

        public static string Lower(string str)
        {
            for (var i = 0; i < str.Length; i++)
            {
                str = str.Replace(str[i], char.ToLower(str[i]));
            }
            return str;
        }

        public static string AddToString(string str)
        {
            return str += "?????";
        }
    }
}
