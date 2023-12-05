using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kr1
{
    class Program
    {
        static void Main(string[] args)
        {
            // задание 1 a
            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();
            char lastLET = str[str.Length - 1];
            Console.WriteLine(str + lastLET);

            // задание 1 b
            int[,] arr = { { 4, 5 }, { 3, -1 } };

            int totalCount = 0;
            foreach(int s in arr)
            {
                if( s > 0)
                {
                    totalCount++;
                }
            }
            Console.WriteLine("Общее число положительных " + totalCount);

            // задание 2

            try
            {
                MyCollerction<int> sIntom = new MyCollerction<int>();
                MyCollerction<double> sDouble = new MyCollerction<double>();

                sIntom.Add(1);
                sIntom.Add(2);

                sDouble.Add(3.3);
                sDouble.Add(4.4);

                
                Console.WriteLine("Нахождение элементa:");
                
                Console.WriteLine(sDouble.Find(4.4));
                
                MyCollerction<char> sChar = new MyCollerction<char>();
                //sChar.Add('f');
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }


            List<char> list = new List<char>{ 'a', 'b', 'f','t', 'r', 'w', 'b' };

            var result = list.OrderBy(c => c);
            var result1 = result.Take(3).Concat(list.Skip(5));
            var result2 = result1.Distinct().ToString();
            foreach(char i in result2)
            {
                Console.Write(i + " ");
            }


        }
    }
}
