using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_OOP
{
    static class StatisticOperation
    {
        public static int sum(this Arr arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.array.Length; i++)
            {
                sum += arr[i];
            }
            return sum;
        }
        public static int max(this Arr arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.array.Length; i++)
            {
                if (max < arr[i])
                {
                    max = arr[i];
                }
            }
            return max;
        }
        public static int min(this Arr arr)
        {
            int min = arr[0];
            for (int i = 0; i < arr.array.Length; i++)
            {
                if (min > arr[i])
                {
                    min = arr[i];
                }
            }
            return min;
        }
        public static int delta(this Arr arr)
        {
            return arr.max() - arr.min();
        }
        public static int size(this Arr arr) 
        {
            return arr.array.Length;
        }

        public static void DeleteAllVowel(this string str)
        {
            var stringBuilder = new StringBuilder();
            var array = new char[] { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U', 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я', 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Э', 'Ю', 'Я' };

            foreach (var e in str)
            {
                var flag = true;
                foreach (var symbol in array)
                {
                    if (e == symbol)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    stringBuilder.Append(e);
                }
            }
            str = stringBuilder.ToString();
            Console.WriteLine(str);
        }

        public static void Delete(this Arr arr)
        {
            Arr result = new Arr(arr.size()-5);
            for (int i = 5; i < arr.size(); i++)
            {
                result[i - 5] = arr[i];
            }
           result.Show();
        }
    }
}
